using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game
{
    [RequireComponent(typeof(PlayerInteractable))]
    public class SimplePoweredDoor : PowerableObject
    {
        public Transform EndpointPositionReference;
        public float TransitionSpeed;
        public PlayerInteractable Interactable;
        public Canvas Canvas;
        public TextMeshProUGUI NoPowerText, LockedText, OpenText;

        [HideInInspector]
        public bool Open;

        private Vector3 _initPos, _targetPos;

        private Vector3 _currentTarget;

        private void Start()
        {
            _initPos = transform.position;
            _targetPos = EndpointPositionReference.position;
            PowerStateChanged();
        }

        public override void PowerStateChanged()
        {
            if (!On)
                SetOpen(false);

            UpdateStateText();
        }
        private void UpdateStateText()
        {
            NoPowerText.gameObject.SetActive(!On);

            bool unlocked = Interactable.requiredCollectables.Length == 0;
            LockedText.gameObject.SetActive(On && !unlocked);
            OpenText.gameObject.SetActive(On && unlocked);
        }

        public void ToggleOpen()
        {
            if(On)
                SetOpen(!Open);
        }
        public void SetOpen(bool open)
        {
            Open = open;
            if (Open)
                _currentTarget = _targetPos;
            else
                _currentTarget = _initPos;
        }

        private void Update()
        {
            transform.position = Vector3.Lerp(transform.position, _currentTarget, Time.deltaTime*TransitionSpeed);
            Canvas.gameObject.SetActive(On || Mathf.Floor(Time.realtimeSinceStartup) % 3 != 0);
        }

    }
}