using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydraulic : MonoBehaviour
{
    public bool isOn;
    Vector3 startPosition;
    public Vector3 endPosition = new Vector3(0,2.5f,0);
    public float travelTime = 0.3f;
    float travelSpeed;
    public Transform piston;
    private Coroutine currentCoroutine;
    
    private void Start()
    {
        travelSpeed = (1 / travelTime) * (startPosition - endPosition).magnitude;
        
        startPosition = piston.localPosition;

        if (isOn)
            piston.localPosition = endPosition;
    }

    public void Toggle()
    {
        isOn = !isOn;
        if(isOn)
            TurnOn();
        else
            TurnOff();
    }

    public void TurnOn()
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOn());
    }

    public void TurnOff()
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOff());
    }
    
    IEnumerator CR_TurnOn()
    {
        while (Vector3.Distance(piston.localPosition,endPosition) > 0.01f)
        {
            piston.localPosition = Vector3.MoveTowards(piston.localPosition,endPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }
        piston.localPosition = endPosition;
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
