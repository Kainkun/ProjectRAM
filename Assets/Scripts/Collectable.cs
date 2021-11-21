using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : PlayerInteractable
{
    public enum CollectableNames {Default, SecurityKey, SecondKey, ThirdKey};

    public static HashSet<CollectableNames> collectedCollectables = new HashSet<CollectableNames>();

    public CollectableNames collectableName;

    public override void InteractSuccess()
    {
        base.InteractSuccess();
        collectedCollectables.Add(collectableName);
        Destroy(gameObject);
    }
}
