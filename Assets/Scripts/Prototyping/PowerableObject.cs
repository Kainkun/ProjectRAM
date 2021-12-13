using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public abstract class PowerableObject : MonoBehaviour
    {
        public UnityEvent<float> PowerPercentChanged;

        public float PowerOnThreshold;

        public bool On { get => _on; }
        private bool _on;
        public float Power { get => _power; }
        private float _power;

        public void SetPower(float power)
        {
            if (_power == power)
                return;

            _power = power;
            bool stateChangeTracker = _on;
            _on = _power >= PowerOnThreshold;

            PowerPercentChanged?.Invoke(Power/PowerOnThreshold);

            PowerLevelChanged();

            if (stateChangeTracker != _on)
                PowerStateChanged();

        }

        public virtual void PowerLevelChanged()
        {

        }
        public virtual void PowerStateChanged()
        {

        }

#if UNITY_EDITOR
        // Debug power state
        void OnDrawGizmosSelected()
        {
            string output = "State: " + (_on?"On":"Off") + "\nPower: " + _power.ToString("n2");
            Handles.Label(transform.position, output);
        }
#endif
    }
}