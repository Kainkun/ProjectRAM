using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dial : PlayerInteractable
{
    public int totalPositions = 4;
    public int currentPosition = 0;
    private int targetPosition;
    private float targetRotation;
    public Transform dial;
    private Coroutine currentCoroutine;

    private void Awake()
    {
        var r = dial.localEulerAngles;
        currentPosition %= totalPositions;
        targetPosition = currentPosition;
        dial.localRotation = Quaternion.Euler(r.x, r.y, currentPosition * (360f/totalPositions));
        targetRotation = dial.localEulerAngles.z % 360;
    }

    public override void Interact()
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_Rotate());
    }
    
    IEnumerator CR_Rotate()
    {
        targetPosition = (targetPosition + 1) % totalPositions;
        targetRotation = targetPosition * (360f / totalPositions);
        
        var r = dial.localEulerAngles;
        while (Mathf.Abs(Mathf.DeltaAngle(dial.localEulerAngles.z,targetRotation)) > 0.1f)
        {
            dial.localRotation = Quaternion.Euler(r.x, r.y, Mathf.MoveTowardsAngle(dial.localEulerAngles.z, targetRotation, Time.deltaTime * 360));
            yield return null;
        }

        currentPosition = targetPosition;
        base.Interact();
    }
}
