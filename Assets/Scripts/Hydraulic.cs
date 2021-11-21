using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydraulic : PlayerInteractableToggle
{
    Vector3 startPosition;
    public Vector3 travelDistance = new Vector3(0,2.5f,0);
    public float travelTime = 0.3f;
    float travelSpeed;
    public Transform piston;
    private Coroutine currentCoroutine;
    
    private void Start()
    {
        travelSpeed = (1 / travelTime) * travelDistance.magnitude;
        
        startPosition = piston.localPosition;

        if (isOn)
            piston.localPosition = travelDistance;
    }

    public override void TurnOn()
    {
        print("ON");
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOn());
        base.TurnOn();
    }

    public override void TurnOff()
    {
        print("OFF");
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOff());
        base.TurnOff();
    }
    
    IEnumerator CR_TurnOn()
    {
        //while (piston.localPosition.y < startPosition + travelDistance)
        while (Vector3.Distance(piston.localPosition, startPosition + travelDistance) > 0.01f)
        {
            piston.localPosition = Vector3.MoveTowards(piston.localPosition, startPosition + travelDistance, Time.deltaTime * travelSpeed);
            yield return null;
        }
        piston.localPosition = startPosition + travelDistance;
    }

    IEnumerator CR_TurnOff()
    {
        while (Vector3.Distance(piston.localPosition, startPosition) > 0.01f)
        {
            piston.localPosition = Vector3.MoveTowards(piston.localPosition, startPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }
        piston.localPosition = startPosition;
    }
}
