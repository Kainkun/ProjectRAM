using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class SimplePowerMeter : MonoBehaviour
    {
        public Image Fill;
        public Gradient Colors;

        private float _targetFill;
        private float _targetColorValue;

        private void Start()
        {
            SetLevel(0);
        }

        private void Update()
        {

            Fill.fillAmount = Mathf.Lerp(Fill.fillAmount, _targetFill, Time.deltaTime * 4f);
            Fill.color = Colors.Evaluate((Fill.fillAmount - .1f )/ .9f );
        }

        public void SetLevel(float level)
        {
            _targetFill = level * .9f + .1f;
            _targetColorValue = level;
        }
    }
}