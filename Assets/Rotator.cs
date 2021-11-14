using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : PlayerInteractable
{
    public int currentPosition = 0;
    public int totalPositions = 4;
    public Transform dial;
    private float targetRotation;
    private Coroutine currentCoroutine;

    private void Start()
    {
        targetRotation = dial.localEulerAngles.z % 360;
    }

    public override void Interact()
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_Rotate());
        base.Interact();
    }
    
    IEnumerator CR_Rotate()
    {
        targetRotation = (targetRotation + 90) % 360;
        
        while (Mathf.Abs(Mathf.DeltaAngle(dial.localEulerAngles.z,targetRotation)) > 1)
        {
            var r = dial.localEulerAngles;
            dial.localRotation = Quaternion.Euler(r.x, r.y, Mathf.MoveTowardsAngle(dial.localEulerAngles.z, targetRotation, Time.deltaTime * 360));
            yield return null;
        }
    }
}
