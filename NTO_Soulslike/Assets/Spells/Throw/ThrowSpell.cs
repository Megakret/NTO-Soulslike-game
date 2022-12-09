using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class ThrowSpell : Spell
{
    public float distance;
    public GameObject ThrowObject;
    private Transform CameraPos;
    public LayerMask IgnoreRaycast;
    
    public override void Activate(ManaHandler manaHandler, HitboxShow hitboxShow, Transform plrCenter)
    {
        CameraPos = Camera.main.GetComponent<Transform>();
        plrCenter.parent.transform.rotation = Quaternion.Euler(0, CameraPos.eulerAngles.y, 0);
        RaycastHit hit;
        Debug.DrawRay(plrCenter.position, CameraPos.forward * distance,Color.black);
        if (Physics.Raycast(plrCenter.position,CameraPos.forward,out hit,distance,IgnoreRaycast))
        {
            Debug.Log("HIT");
        }

        
    }
    
}
