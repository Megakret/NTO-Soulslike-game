using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StrongSlash : Spell
{
    public float DamageMultiplier;
    public float RangeMultiplier;
    public LayerMask WhatIsEnemies;

    public override void Activate(ManaHandler manaHandler, HitboxShow hitboxShow)
    {
        Weapon _weapon = manaHandler.GetComponent<WeaponHolder>()._weapon;
        Transform plr = manaHandler.GetComponent<Transform>();
        Transform hitboxCenter = plr.GetChild(2).GetComponent<Transform>();
        
        
        float Range = _weapon.weaponRange * RangeMultiplier;
        Collider[] Enemies = Physics.OverlapBox(hitboxCenter.position - hitboxCenter.forward * Range/2, new Vector3(1,2,Range), hitboxCenter.rotation, WhatIsEnemies);
        hitboxShow.BoxShow(hitboxCenter.position - hitboxCenter.forward * Range / 2, new Vector3(1, 2, Range), hitboxCenter.rotation);
        Debug.Log("Spell!");

        foreach (Collider enemy in Enemies)
        {
            
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(_weapon.Damage * DamageMultiplier);

        }
    }
   
    
}
