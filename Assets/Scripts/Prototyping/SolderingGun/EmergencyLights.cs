using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class EmergencyLights : PowerableObject
    {
        public List<Light> RedLights;
        public List<Light> HouseLights;
        public AnimationCurve RedLightIntensity, HouseLightIntensity;

        private void Start()
        {
            PowerStateChanged();
        }

        public override void PowerStateChanged()
        {
            foreach (Light l in RedLights)
                l.enabled = !On;
            foreach (Light l in HouseLights)
                l.enabled = On;
        }

        private void Update()
        {
            if (On)
            {
                foreach (Light l in HouseLights)
                    l.intensity = HouseLightIntensity.Evaluate(Time.realtimeSinceStartup);
            }
            else
            {
                foreach (Light l in RedLights)
                    l.intensity = RedLightIntensity.Evaluate(Time.realtimeSinceStartup);
            }
        }
    }
}