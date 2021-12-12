using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplaceAllMaterialsInScene : MonoBehaviour
{
    [EasyButtons.Button]
    public void Replace(Material from, Material to)
    {
        foreach (MeshRenderer meshRenderer in Object.FindObjectsOfType<MeshRenderer>())
        {
            print("----------------------");
            print(meshRenderer.sharedMaterial);
            if (meshRenderer.sharedMaterial == from)
            {
                print("REPLACING THIS ONE: " + meshRenderer.gameObject.name);
                meshRenderer.sharedMaterial = to;
            }
        }
    }
}
