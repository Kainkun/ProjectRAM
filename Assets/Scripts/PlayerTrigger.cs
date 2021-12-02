using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    public bool oneTimeUse = true;
    private bool used = false;
    public UnityEvent onPlayerEnter;
    public UnityEvent onPlayerExit;

    private void OnDrawGizmos()
    {
        Matrix4x4 rotationMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale);
        Gizmos.matrix = rotationMatrix;
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (oneTimeUse && used)
                return;
            
            used = true;
            onPlayerEnter.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && (oneTimeUse && !used))
        {
            if (oneTimeUse && used)
                return;
            
            used = true;
            onPlayerExit.Invoke();
        }
    }
}
