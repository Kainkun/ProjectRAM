using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionSystem : MonoBehaviour
{
    public Camera playerCamera;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
            {
                PlayerInteractable interactable = hit.transform.GetComponent<PlayerInteractable>();
                if (interactable)
                {
                    interactable.Interact();
                }
            }
        }
    }
}
