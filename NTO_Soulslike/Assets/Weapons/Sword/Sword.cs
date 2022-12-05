using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Sword : Weapon
{
    public float SpecialRadius;
    public override void SpecialAbility(WeaponHolder weaponManager, HitboxShow hitboxShow) // ����� ��� ��������� �������� �� 3 �����
    {
        Debug.Log("Final Hit");
        Collider[] Enemies = Physics.OverlapSphere(weaponManager.gameObject.transform.position, SpecialRadius, weaponManager.WhatIsEnemies);
        hitboxShow.SphereShow(weaponManager.gameObject.transform.position, SpecialRadius);
        foreach (Collider enemy in Enemies)
        {
            
            enemy.GetComponent<Enemy>().TakeDamage(10);
            ManaHandler.Mana += ManaPerHit;

        }

    }
}
