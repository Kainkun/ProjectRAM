using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractable : MonoBehaviour
{
    public bool isOneTimeUse;
    private bool hasBeenUsed;
    public UnityEvent onInteract;

    public virtual void Interact()
    {
        if (isOneTimeUse && hasBeenUsed)
            return;
        
        onInteract.Invoke();
        hasBeenUsed = true;
    }
}
