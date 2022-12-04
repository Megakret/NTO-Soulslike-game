using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class StrongSlash : Spell
{
    public float DamageMultiplier;
    public float RangeMultiplier;
    public LayerMask WhatIsEnemies;

    public override void Activate(GameObject plr)
    {
        Weapon _weapon = plr.GetComponent<WeaponHolder>()._weapon;
        float Range = _weapon.weaponRange * RangeMultiplier;
        Collider[] Enemies = Physics.OverlapBox(plr.transform.position - new Vector3(0,0,Range/2), new Vector3(2,2,Range),plr.transform.rotation, WhatIsEnemies);
        Debug.Log("Spell!");

        foreach (Collider enemy in Enemies)
        {
            Debug.Log("HIT");
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(_weapon.Damage * DamageMultiplier);

        }
    }
   
    
}
