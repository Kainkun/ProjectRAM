using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Game
{
    // This soldering set is hyper-prototype code. Refactor if planning continued use.
    public class SolderConnector : PowerableObject
    {
        public static Action CheckPowered;

        public float ConnectionRadius = .5f;
        [HideInInspector]
        public List<SolderConnector> Connections;

        [HideInInspector]
        /// <summary>
        /// Sent state each frame then reset in SolderGunController
        /// </summary>
        public Dictionary<int,float> PowerThisFrame;

        private Dictionary<int, float> _powerLastFrame;

        protected virtual void Start()
        {
            Connections = new List<SolderConnector>();
            PowerThisFrame = new Dictionary<int, float>();
            _powerLastFrame = PowerThisFrame;
            CheckPowered += CheckPower;
        }

        public void Connect(SolderConnector ball)
        {
            // No I'm not redundancy checking fuck you
            Connections.Add(ball);
        }

        public void Disconnect(SolderConnector ball)
        {
            Connections.Remove(ball);
        }

        protected virtual void CheckPower()
        {
            // I know, this chugs. Like I said, prototype.
            _powerLastFrame = new Dictionary<int,float>(PowerThisFrame);
            SetPower(PowerThisFrame.Sum(x => x.Value));
            PowerThisFrame = PowerThisFrame.ToDictionary(p => p.Key, p => 0f);
            // Note: PowerThisFrame.Clear will FUCK UP performance due to gc
            // But that's only because this temp solution sucks
        }

        public void Break()
        {
            while (Connections.Count > 0)
            {
                Connections[0].Disconnect(this);
                Connections.RemoveAt(0);
            }
            CheckPowered -= CheckPower;
            Destroy(gameObject);
        }



#if UNITY_EDITOR
        // Debug power state
        void OnDrawGizmosSelected()
        {
            if (_powerLastFrame == null)
                return;

            string output = "Power:";
            foreach(KeyValuePair<int,float> kvp in _powerLastFrame)
                output += "\n" + kvp.Key.ToString() + " : " + kvp.Value.ToString("n2");
            Handles.Label(transform.position, output);
        }
#endif

    }
}