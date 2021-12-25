using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ArCamera : MonoBehaviour
{
    // private Camera playerFPScam;
    // private Camera arCamera;
    // public float moveSpeed = 15;
    // public float rotateSpeed = 25;
    // private bool followPlayerFPScam = true;
    //
    // private void Start()
    // {
    //     arCamera = GetComponent<Camera>();
    //     playerFPScam = Camera.main;
    //
    //     transform.position = playerFPScam.transform.position;
    //     transform.rotation = playerFPScam.transform.rotation;
    // }
    //
    // private void Update()
    // {
    //     if (followPlayerFPScam)
    //     {
    //         transform.position = Vector3.Lerp(transform.position, playerFPScam.transform.position, moveSpeed * Time.deltaTime);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, playerFPScam.transform.rotation, rotateSpeed * Time.deltaTime);
    //     }
    // }
    //
    // private void OnTriggerEnter(Collider other)
    // {
    //     if (other.GetComponent<ArScreenRenderTextureSetter>())
    //     {
    //         StartCoroutine(StartAr());
    //     }
    // }
    //
    // private void OnTriggerExit(Collider other)
    // {
    //     if (other.GetComponent<ArScreenRenderTextureSetter>())
    //     {
    //         StartCoroutine(EndAr());
    //     }
    // }
    //
    // IEnumerator StartAr()
    // {
    //     print("aaaaaaaaa");
    //     arCamera.enabled = true;
    //     followPlayerFPScam = false;
    //
    //     float min = 5;
    //     float max = 10;
    //     transform.Rotate(Random.Range(0, 2) * 2 - 1 * Random.Range(min, max), Random.Range(0, 2) * 2 - 1 * Random.Range(min, max), Random.Range(0, 2) * 2 - 1 * Random.Range(min, max));
    //     yield return new WaitForSeconds(0.5f);
    //     transform.rotation = playerFPScam.transform.rotation;
    //
    //     followPlayerFPScam = true;
    //     yield return null;
    // }
    //
    // IEnumerator EndAr()
    // {
    //     arCamera.enabled = false;
    //
    //     yield return null;
    // }
}