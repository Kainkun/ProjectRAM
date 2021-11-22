using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : PlayerInteractable
{
    Vector3 startPosition;
    public Vector3 endPosition = new Vector3(0,0,0);
    public float travelTime = 0.2f;
    float travelSpeed;
    public Transform buttonTransform;
    private Coroutine currentCoroutine;
    private bool buttonSuccess;
    
    private void Start()
    {
        startPosition = buttonTransform.localPosition;
        
        travelSpeed = (1 / travelTime) * (startPosition - endPosition).magnitude;
    }

    public override void Interact()
    {
        if(currentCoroutine != null)
            StopCoroutine(currentCoroutine);
        currentCoroutine = StartCoroutine(CR_Press());
        base.Interact();
    }

    public override void InteractSuccess()
    {
        buttonSuccess = true;
    }

    public override void InteractFail()
    {
        buttonSuccess = false;
    }


    IEnumerator CR_Press()
    {
        while (Vector3.Distance(buttonTransform.localPosition,endPosition) > 0.001f)
        {
            buttonTransform.localPosition = Vector3.MoveTowards(buttonTransform.localPosition,endPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }

        if(buttonSuccess)
            base.InteractSuccess();
        else
            base.InteractFail();

        yield return new WaitForSeconds(0.2f);
        
        while (Vector3.Distance(buttonTransform.localPosition,startPosition) > 0.001f)
        {
            buttonTransform.localPosition = Vector3.MoveTowards(buttonTransform.localPosition,startPosition, Time.deltaTime * travelSpeed);
            yield return null;
        }
        
        buttonTransform.localPosition = startPosition;
    }

}
