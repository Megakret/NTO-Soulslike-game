using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Sword : Weapon
{
    public float SpecialRadius;
    public int UltimateDamage;
    public override void SpecialAbility(WeaponHolder weaponManager, HitboxShow hitboxShow) // Здесь код особенной способки на 3 ударе
    {
        //Debug.Log("Final Hit");
        Collider[] Enemies = Physics.OverlapSphere(weaponManager.gameObject.transform.position, SpecialRadius, weaponManager.WhatIsEnemies);
        ManaHandler manaHandler = weaponManager.GetComponent<ManaHandler>();
        GameObject plr = manaHandler.gameObject;
        hitboxShow.SphereShow(weaponManager.gameObject.transform.position, SpecialRadius);
        plr.GetComponent<AnimatorScript>().FinalSwordAttack();
        foreach (Collider collider in Enemies)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy.IsParrying == true)
            {
                PlrStun plrStun = plr.GetComponent<PlrStun>();
                plrStun.GetStun(1.5f);
            }
            else
            {
                enemy.GetComponent<Enemy>().TakeDamage(UltimateDamage);
                manaHandler.Mana += ManaPerHit;
            }

        }

    }
}
