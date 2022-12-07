using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StrongSlash : Spell
{
    public float DamageMultiplier;
    public float RangeMultiplier;
    public LayerMask WhatIsEnemies;

    public override void Activate(ManaHandler manaHandler, HitboxShow hitboxShow, Transform plrCenter)
    {
        Weapon _weapon = manaHandler.GetComponent<WeaponHolder>()._weapon;
        float Range = _weapon.weaponRange * RangeMultiplier;
        Collider[] Enemies = Physics.OverlapBox(plrCenter.position + plrCenter.forward * Range/2, new Vector3(1,2,Range), plrCenter.rotation, WhatIsEnemies);
        hitboxShow.BoxShow(plrCenter.position + plrCenter.forward * Range / 2, new Vector3(1, 2, Range), plrCenter.rotation);
        Debug.Log("Spell!");

        foreach (Collider enemy in Enemies)
        {
            
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(_weapon.Damage * DamageMultiplier);

        }
    }
   
    
}
