using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ThrowSpell : Spell
{
    public float distance;
    public GameObject ThrowObject;
    private Transform CameraPos;

    
    public override void Activate(ManaHandler manaHandler, HitboxShow hitboxShow, Transform plrCenter)
    {
        CameraPos = Camera.main.GetComponent<Transform>();
        

        
    }
}
