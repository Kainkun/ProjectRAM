using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class SolderingGunController : MonoBehaviour
    {
        public float FireInterval = .05f;
        public MonoBehaviour BallPrefab, RemoverPrefab;
        public float FireVelocity, SuctionVelocity;

        private GameObject _solderParent;
        private bool _firing;

        private float _firingTimer;

        private void Start()
        {
            _solderParent = new GameObject("Soldering Parent");
        }

        void Update()
        {
            if (Input.GetMouseButton(0))
                TickBallLaunch(Time.deltaTime, BallPrefab.gameObject, FireVelocity);
            else if (Input.GetMouseButton(1))
                TickBallLaunch(Time.deltaTime, RemoverPrefab.gameObject, SuctionVelocity);
            else if (Input.GetMouseButtonDown(2))
            {
                // HYPER slow obviously
                SolderBall[] allBalls = GameObject.FindObjectsOfType<SolderBall>();
                for (int i = 0; i < allBalls.Length; i++)
                    allBalls[i].Break();
            }

            // Always run power sources first to set state this frame, then connectors to check it
            SolderPowerSource.SendPower?.Invoke();
            SolderConnector.CheckPowered?.Invoke();
        }

        void TickBallLaunch(float deltaTime, GameObject prefab, float velocity)
        {
            _firingTimer -= deltaTime;
            if (_firingTimer <= 0)
            {
                _firingTimer = FireInterval;
                Rigidbody newBall = GameObject.Instantiate(prefab, transform.position + transform.forward, Quaternion.identity, _solderParent.transform).GetComponent<Rigidbody>();
                newBall.velocity = transform.forward * velocity;
                newBall.transform.forward = transform.forward;
            }
        }
    }
}