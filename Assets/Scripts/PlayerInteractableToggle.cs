using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInteractableToggle : PlayerInteractable
{
    public bool isOn;
    public UnityEvent onTurnOn;
    public UnityEvent onTurnOff;

    public override void InteractSuccess()
    {
        isOn = !isOn;

        if (isOn)
            TurnOn();
        else
            TurnOff();

        base.Interact();
    }

    public virtual void TurnOn()
    {
        onTurnOn.Invoke();
    }

    public virtual void TurnOff()
    {
        onTurnOff.Invoke();
    }
}