using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydraulic : PlayerInteractableToggle
{
    float startY;
    public float travelDistance = 2.5f;
    public float travelTime = 0.3f;
    float travelSpeed;
    public Transform piston;
    private Coroutine currentCoroutine;
    
    private void Start()
    {
        travelSpeed = (1 / travelTime) * travelDistance;
        startY = piston.localPosition.y;

        if (isOn)
            piston.localPosition = new Vector3(0, startY + travelDistance, 0);
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
        while (piston.localPosition.y < startY + travelDistance)
        {
            piston.localPosition += new Vector3(0, Time.deltaTime * travelSpeed, 0);
            yield return null;
        }
        piston.localPosition = new Vector3(0, startY + travelDistance, 0);
    }

    IEnumerator CR_TurnOff()
    {
        while (piston.localPosition.y > startY)
        {
            piston.localPosition -= new Vector3(0, Time.deltaTime * travelSpeed, 0);
            yield return null;
        }
        piston.localPosition = new Vector3(0, startY, 0);
    }
}
