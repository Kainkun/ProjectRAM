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
    public Transform pistonTransform;
    private Coroutine currentCoroutine;
    
    private void Start()
    {
        startPosition = pistonTransform.localPosition;
        
        travelSpeed = (1 / travelTime) * (startPosition - endPosition).magnitude;

        if (isOn)
            pistonTransform.localPosition = endPosition;
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
        isOn = true;
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOn());
    }

    public void TurnOff()
    {
        isOn = false;
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_TurnOff());
    }
    
    IEnumerator CR_TurnOn()
    {
        while (Vector3.Distance(pistonTransform.localPosition,endPosition) > 0.001f)
        {
            pistonTransform.localPosition = Vector3.MoveTowards(pistonTransform.localPosition,endPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }
        pistonTransform.localPosition = endPosition;
    }

    IEnumerator CR_TurnOff()
    {
        while (Vector3.Distance(pistonTransform.localPosition, startPosition) > 0.001f)
        {
            pistonTransform.localPosition = Vector3.MoveTowards(pistonTransform.localPosition, startPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }
        pistonTransform.localPosition = startPosition;
    }
}
