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
        Transform CameraPos = Camera.main.transform;
        Weapon _weapon = manaHandler.GetComponent<WeaponHolder>()._weapon; // �������� �������� ������
        float Range = _weapon.weaponRange * RangeMultiplier; // ��������� ��������� ����������
        Collider[] Enemies = Physics.OverlapBox(plrCenter.position + plrCenter.forward * Range/2, new Vector3(1,2,Range), plrCenter.rotation, WhatIsEnemies); // ������� �������
        hitboxShow.BoxShow(plrCenter.position + plrCenter.forward * Range / 2, new Vector3(1, 2, Range), plrCenter.rotation);
        plrCenter.parent.rotation = Quaternion.Euler(0,CameraPos.eulerAngles.y,0);
        GameObject plr = manaHandler.gameObject;
        
        //Debug.Log("Spell!");

        foreach (Collider collider in Enemies)
        {
            Enemy enemy = collider.gameObject.GetComponent<Enemy>();
            if (enemy.IsParrying == true)
            {
                PlrStun plrStun = plr.GetComponent<PlrStun>();
                plrStun.GetStun(1.5f);
            }
            enemy.gameObject.GetComponent<Enemy>().TakeDamage(_weapon.Damage * DamageMultiplier);

        }
    }
   
    
}
