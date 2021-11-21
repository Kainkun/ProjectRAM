using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialLock : MonoBehaviour
{
    [System.Serializable]
    public struct DialPasswordPair
    {
        public Dial dial;
        public int[] unlockPositions;
    }

    public DialPasswordPair[] dialPasswordPairs;
    public UnityEvent onUnlock;
    public UnityEvent onLock;
    public bool isLocked = true;

    private void Start()
    {
        foreach (DialPasswordPair dialPasswordPair in dialPasswordPairs)
            dialPasswordPair.dial.onInteract.AddListener(CheckLock);

        CheckLock();
    }

    public void CheckLock()
    {
        foreach (DialPasswordPair dialPasswordPair in dialPasswordPairs)
        {
            bool foundCorrectPosition = false;
            foreach (int unlockPosition in dialPasswordPair.unlockPositions)
            {
                if (dialPasswordPair.dial.currentPosition == unlockPosition)
                {
                    foundCorrectPosition = true;
                }
            }

            if (!foundCorrectPosition)
            {
                if (!isLocked)
                {
                    isLocked = true;
                    onLock.Invoke();
                }

                return;
            }
        }

        if (isLocked)
        {
            isLocked = false;
            onUnlock.Invoke();
        }
    }
}