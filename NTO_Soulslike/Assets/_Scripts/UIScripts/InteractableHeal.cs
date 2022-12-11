using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHeal : Interactable
{
    public int PancakeCount;
    public override void Interacting(GameObject plr)
    {
        Healing healing = plr.GetComponent<Healing>();
        healing.HealCount += PancakeCount;
        Destroy(gameObject.transform.parent.gameObject);
    }
}
