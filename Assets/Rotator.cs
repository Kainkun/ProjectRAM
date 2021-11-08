using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : PlayerInteractable
{
    public int currentPosition = 0;
    public int totalPositions = 4;
    public Transform dial;
    
    public override void Interact()
    {
        StartCoroutine(CR_Rotate());
        base.Interact();
    }
    
    IEnumerator CR_Rotate()
    {
        float start = dial.localEulerAngles.z;
        float target = start + 90;

        yield return null;

        float t = 0;
        while (t < 1)
        {
            var r = dial.localEulerAngles;
            dial.localRotation = Quaternion.Euler(r.x, r.y, Mathf.LerpAngle(start, target, t));
            t += Time.deltaTime;
            yield return null;
        }
    }
}
