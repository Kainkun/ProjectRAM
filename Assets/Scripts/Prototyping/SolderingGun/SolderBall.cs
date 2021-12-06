using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class SolderBall : SolderConnector
    {
        public bool Airborne = true;
        public MeshRenderer BallForm, SplatForm;


        public Rigidbody Rigidbody;

        protected override void Start()
        {
            base.Start();
            Rigidbody = GetComponent<Rigidbody>();
        }

        public void Land(Vector3 impactPoint, Vector3 impactNormal)
        {
            if (!Airborne)
                return;
            Airborne = false;

            // Stop
            Rigidbody.useGravity = false;
            Rigidbody.velocity = Vector3.zero;
            Rigidbody.isKinematic = true;

            // Look
            transform.position = impactPoint;
            transform.up = impactNormal;
            BallForm.gameObject.SetActive(false);
            SplatForm.gameObject.SetActive(true);

            // Listen
            foreach(Collider c in Physics.OverlapSphere(transform.position, ConnectionRadius))
            {
                // This is slow and sloppy. Also a prototype, shoot me.
                SolderConnector foundConnector = c.gameObject.GetComponent<SolderConnector>();
                if (foundConnector != null)
                {
                    foundConnector.Connect(this);
                    Connect(foundConnector);
                }
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Solderable"))
            {
                ContactPoint firstContact = collision.GetContact(0);
                Land(firstContact.point, firstContact.normal);
            }
        }


    }
}