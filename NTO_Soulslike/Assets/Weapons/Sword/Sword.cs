using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Sword : Weapon
{
    public override void SpecialAbility(WeaponHolder weaponManager) // ����� ��� ��������� �������� �� 3 �����
    {
        Debug.Log("Final Hit");
        Collider[] Enemies = Physics.OverlapSphere(weaponManager.gameObject.transform.position, 10, weaponManager.WhatIsEnemies);
        foreach (Collider enemy in Enemies)
        {
            enemy.GetComponent<Enemy>().TakeDamage(10);

        }

    }
}
