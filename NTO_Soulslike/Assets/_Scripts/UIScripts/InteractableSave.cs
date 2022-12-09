using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSave : Interactable
{
    public Vector3 spawnPoint;
    public override void Interacting(GameObject plr)
    {
        PlayerHP playerHP = plr.GetComponent<PlayerHP>();
        playerHP.SpawnPoint = spawnPoint;
    }
}
