using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Spear : Weapon
{
    [Header("UltimateStats")]
    public float UltimateRange;
    public float dashTime;
    public float dashSpeed;
    public int UltimateDamage;
    public override void SpecialAbility(WeaponHolder weaponManager, HitboxShow hitboxShow)
    {
        
        Collider[] Enemies = Physics.OverlapBox(weaponManager.gameObject.transform.position + weaponManager.transform.forward * UltimateRange/2,new Vector3(2,3,UltimateRange/2), weaponManager.transform.rotation,weaponManager.WhatIsEnemies);
        hitboxShow.BoxShow(weaponManager.gameObject.transform.position + weaponManager.transform.forward * UltimateRange / 2, new Vector3(3, 3, UltimateRange), weaponManager.transform.rotation);
        ManaHandler manaHandler = weaponManager.GetComponent<ManaHandler>();
        
        foreach (Collider enemy in Enemies)
        {

            enemy.GetComponent<Enemy>().TakeDamage(UltimateDamage);
            manaHandler.Mana += ManaPerHit;

        }
        Dodging dashManager = weaponManager.GetComponent<Dodging>();
        
        dashManager.StartCoroutine(dashManager.Dodge(dashSpeed,dashTime));
        
        
        
    }
    
}
