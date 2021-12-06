using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(Rigidbody))]
    public class SolderRemover : MonoBehaviour
    {
        public float LifeSpan = 0.5f;
        IEnumerator Start()
        {
            yield return new WaitForSeconds(LifeSpan);
            GameObject.Destroy(gameObject);
        }
        private void OnTriggerEnter(Collider other)
        {
            SolderBall ball = other.GetComponent<SolderBall>();
            if (ball != null)
            {
                ball.Break();
            }
        }
    }
}