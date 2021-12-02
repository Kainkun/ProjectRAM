using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestructableBox : MonoBehaviour
{
    public float delay;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Crusher")
        {
            StartCoroutine(CR_Destroy());
        }
    }

    private IEnumerator CR_Destroy()
    {
        yield return new WaitForSeconds(delay);
        var ps = transform.GetChild(0).GetComponent<ParticleSystem>();
        ps.transform.parent = null;
        ps.Play();
        Destroy(gameObject);
    }

}
