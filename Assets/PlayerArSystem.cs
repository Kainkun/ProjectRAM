using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerArSystem : MonoBehaviour
{
    private Camera playerFPScam;
    public Camera arCamera;
    public float moveSpeed = 15;
    public float rotateSpeed = 25;
    private bool followPlayerFPScam = true;
    public VolumeProfile screenAdderVolumeProfile;

    
    private void Start()
    {
        playerFPScam = GetComponentInChildren<Camera>();
        arCamera.enabled = false;
    }

    private void Update()
    {
        if (followPlayerFPScam)
        {
            arCamera.transform.position = Vector3.Lerp(arCamera.transform.position, playerFPScam.transform.position, moveSpeed * Time.deltaTime);
            arCamera.transform.rotation = Quaternion.Lerp(arCamera.transform.rotation, playerFPScam.transform.rotation, rotateSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Volume volume = other.GetComponent<Volume>();
        if(volume && volume.sharedProfile == screenAdderVolumeProfile)
        {
            StartCoroutine(StartAr(volume));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        Volume volume = other.GetComponent<Volume>();
        if(volume && volume.sharedProfile == screenAdderVolumeProfile)
        {
            StartCoroutine(EndAr(volume));
        }
    }
    
    IEnumerator StartAr(Volume volume)
    {
        arCamera.enabled = true;
        followPlayerFPScam = false;
        
        arCamera.transform.position = playerFPScam.transform.position;
        arCamera.transform.rotation = playerFPScam.transform.rotation;
    
        for (int i = 0; i < 2; i++)
        {
            float min = 1;
            float max = 2;
            arCamera.transform.Rotate((Random.Range(0, 2) * 2 - 1) * Random.Range(min, max), (Random.Range(0, 2) * 2 - 1) * Random.Range(min, max), (Random.Range(0, 2) * 2 - 1) * Random.Range(min, max));
            yield return new WaitForSeconds(0.05f);
            volume.weight = 0;
            yield return new WaitForSeconds(0.05f);
            volume.weight = 1;
        }
    
    
        arCamera.transform.rotation = playerFPScam.transform.rotation;
    
        followPlayerFPScam = true;
    }
    
    IEnumerator EndAr(Volume volume)
    {
        followPlayerFPScam = false;

        for (int i = 0; i < 2; i++)
        {
            float min = 1;
            float max = 2;
            arCamera.transform.Rotate((Random.Range(0, 2) * 2 - 1) * Random.Range(min, max), (Random.Range(0, 2) * 2 - 1) * Random.Range(min, max), (Random.Range(0, 2) * 2 - 1) * Random.Range(min, max));
            yield return new WaitForSeconds(0.05f);
            volume.weight = 1;
            yield return new WaitForSeconds(0.05f);
            volume.weight = 0;
        }
        
        arCamera.enabled = false;
    }
}