using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArCamera : MonoBehaviour
{
    private Camera playerFPScam;
    public float moveSpeed = 15;
    public float rotateSpeed = 25;

    private void Start()
    {
        playerFPScam = Camera.main;

        transform.position = playerFPScam.transform.position;
        transform.rotation = playerFPScam.transform.rotation;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, playerFPScam.transform.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, playerFPScam.transform.rotation, rotateSpeed * Time.deltaTime);
    }
}
