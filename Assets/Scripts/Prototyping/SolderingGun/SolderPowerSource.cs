using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class SolderPowerSource : SolderConnector
    {
        public static Action SendPower;
        public static int HighestID;

        public float ActivePowerLevel = 1f;
        private int _id;
        private List<SolderConnector> _powerAbsorbers;

        protected override void Start()
        {
            base.Start();

            SendPower += RunPower;
            _id = HighestID;
            HighestID++;
        }

        private void RunPower()
        {
            _powerAbsorbers = new List<SolderConnector>();
            PowerConnector(this);
            _powerAbsorbers = _powerAbsorbers.OrderBy(x => x.PowerOnThreshold).ToList();

            if (_powerAbsorbers.Count == 0)
                return;

            // Apply power to the actual sources
            float powerToGive = ActivePowerLevel;
            for(int i = 0; i < _powerAbsorbers.Count; i++)
            {
                float allotedPower = powerToGive / (_powerAbsorbers.Count - i);
                float powerTaken =  _powerAbsorbers[i].PowerOnThreshold>= allotedPower? allotedPower: allotedPower - _powerAbsorbers[i].PowerOnThreshold;
                powerToGive -= powerTaken;
                _powerAbsorbers[i].PowerThisFrame[_id] = powerTaken;
            }
        }

        private void PowerConnector(SolderConnector c)
        {
            foreach (SolderConnector secondaryConnector in c.Connections)
            {
                if (!secondaryConnector.PowerThisFrame.ContainsKey(_id) || secondaryConnector.PowerThisFrame[_id]==0f)
                {
                    // Actually receives power in RunPower()
                    if (secondaryConnector.PowerOnThreshold != 0 && !_powerAbsorbers.Contains(secondaryConnector)) 
                            _powerAbsorbers.Add(secondaryConnector);
                    else // Symbolically receives power (good for debugging)
                        secondaryConnector.PowerThisFrame[_id] = ActivePowerLevel;
                    PowerConnector(secondaryConnector);
                }
            }
        }
    }
}