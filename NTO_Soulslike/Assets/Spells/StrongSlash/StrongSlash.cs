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
        float Range = _weapon.weaponRange * RangeMultiplier;
        Collider[] Enemies = Physics.OverlapBox(plr.position - plr.forward * Range/2, new Vector3(2,2,Range),plr.rotation, WhatIsEnemies);
        Debug.Log("Spell!");

        foreach (Collider enemy in Enemies)
        {
            
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(_weapon.Damage * DamageMultiplier);

        }
    }
   
    
}
