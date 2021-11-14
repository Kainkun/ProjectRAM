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
    public class DialPasswordPair
    {
        public Dial dial;
        public int unlockPosition;
    }

    public DialPasswordPair[] dialPasswordPairs;
    public UnityEvent onUnlock;
    public UnityEvent onLock;
    public bool isLocked = true;

    private void Start()
    {
        foreach (DialPasswordPair dialPasswordPair in dialPasswordPairs)
        {
            dialPasswordPair.dial.onInteract.AddListener(CheckLock);
            dialPasswordPair.unlockPosition %= dialPasswordPair.dial.totalPositions;
        }

        CheckLock();
    }

    public void CheckLock()
    {
        foreach (DialPasswordPair dialPasswordPair in dialPasswordPairs)
            if (dialPasswordPair.dial.currentPosition != dialPasswordPair.unlockPosition)
            {
                if (!isLocked)
                {
                    isLocked = true;
                    onLock.Invoke();
                }
                return;
            }

        isLocked = false;
        onUnlock.Invoke();
    }
}