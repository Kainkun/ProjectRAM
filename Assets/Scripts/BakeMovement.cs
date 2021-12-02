using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeMovement : MonoBehaviour
{
    public AnimationClip animationClip;
    public float recordTime = 3;

    private AnimationCurve animationCurvePX = new AnimationCurve();
    private AnimationCurve animationCurvePY = new AnimationCurve();
    private AnimationCurve animationCurvePZ = new AnimationCurve();

    private AnimationCurve animationCurveRX = new AnimationCurve();
    private AnimationCurve animationCurveRY = new AnimationCurve();
    private AnimationCurve animationCurveRZ = new AnimationCurve();


    private void Start()
    {
        StartCoroutine(Record());
    }

    private void Update()
    {
        print(Time.time);
    }

    // private void FixedUpdate()
    // {
    //     if(Time.time <= recordTime)
    //     {
    //         animationCurvePX.AddKey(Time.time, transform.position.x);
    //         animationCurvePY.AddKey(Time.time, transform.position.y);
    //         animationCurvePZ.AddKey(Time.time, transform.position.z);
    //
    //         animationCurveRX.AddKey(Time.time, transform.rotation.x);
    //         animationCurveRY.AddKey(Time.time, transform.rotation.y);
    //         animationCurveRZ.AddKey(Time.time, transform.rotation.z);
    //     }
    // }

    IEnumerator Record()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Rigidbody>().isKinematic = false;

        
        while (Time.time <= recordTime + 5)
        {
            animationCurvePX.AddKey(Time.time - 5, transform.position.x);
            animationCurvePY.AddKey(Time.time - 5, transform.position.y);
            animationCurvePZ.AddKey(Time.time - 5, transform.position.z);
            
            animationCurveRX.AddKey(Time.time - 5, transform.rotation.x);
            animationCurveRY.AddKey(Time.time - 5, transform.rotation.y);
            animationCurveRZ.AddKey(Time.time - 5, transform.rotation.z);
            
            yield return new WaitForSeconds(5f/60f);
        }
        
        
        //yield return new WaitForSeconds(recordTime + 0.5f);
        animationClip.SetCurve("", typeof(Transform), "localPosition.x", animationCurvePX);
        animationClip.SetCurve("", typeof(Transform), "localPosition.y", animationCurvePY);
        animationClip.SetCurve("", typeof(Transform), "localPosition.z", animationCurvePZ);

        animationClip.SetCurve("", typeof(Transform), "localRotation.x", animationCurveRX);
        animationClip.SetCurve("", typeof(Transform), "localRotation.y", animationCurveRY);
        animationClip.SetCurve("", typeof(Transform), "localRotation.z", animationCurveRZ);
    }
}