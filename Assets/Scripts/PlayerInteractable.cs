using Configs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractable : MonoBehaviour
{
    public bool isOneTimeUse;
    private bool isUsed;
    public Collectable.CollectableNames[] requiredCollectables;
    public UnityEvent onInteractSuccess;
    public UnityEvent onInteractFail;

    public virtual void Interact()
    {
        if (isOneTimeUse && isUsed)
            return;

        if (!MeetsRequirements())
        {
            InteractFail();
            onInteractFail.Invoke();
            return;
        }

        InteractSuccess();
        onInteractSuccess.Invoke();
        isUsed = true;
    }

    public virtual bool MeetsRequirements()
    {
        foreach (Collectable.CollectableNames requiredCollectable in requiredCollectables)
            if (!Collectable.collectedCollectables.Contains(requiredCollectable))
                return false;
        return true;
    }

    public virtual void InteractSuccess()
    {
        
    }

    public virtual void InteractFail()
    {
        
    }
}
