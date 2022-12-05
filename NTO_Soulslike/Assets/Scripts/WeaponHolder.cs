using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoCache
{
    
    public Weapon _weapon;
    public Transform hitboxCenter;
    public LayerMask WhatIsEnemies;
    public HitboxShow hitboxShow;
    public int ManaPerHit;
    
    private float comboNum = 0; 
    private float prevTick;
    private bool CanHit = true;
    
    void Start()
    {
        prevTick = Time.time;
        
        
    }

    // Update is called once per frame
    public override void OnTick()
    {
        if (Input.GetButtonDown("Fire1") && CanHit)
        {
            Click();
        }
    }
    public void Click() // ����
    {
        float nowTick = Time.time;
        if(nowTick - prevTick >= _weapon.maxComboDelay) // ����� �����, ���� ����� �� �������� ������� �����
        {
            comboNum = 0;
            prevTick = Time.time;
            StartCoroutine(AfterComboCd());

        }
        comboNum++;
        
        if(comboNum == 3) // ����������� �����
        {
            _weapon.SpecialAbility(this,hitboxShow);
            StartCoroutine(AfterComboCd());
            comboNum = 0;

        }
        else
        {
            
            StartCoroutine(HitCd());
            Attack();
            
        }
        Debug.Log("Hit");
        CanHit = false;
        prevTick = Time.time;

        


    }
    
    public void Attack() // ���� �����
    {
        Collider[] Enemies = Physics.OverlapBox(hitboxCenter.position -  hitboxCenter.forward * _weapon.weaponRange / 2, new Vector3(1, 2, _weapon.weaponRange), hitboxCenter.rotation, WhatIsEnemies);
        hitboxShow.BoxShow(hitboxCenter.position - hitboxCenter.forward * _weapon.weaponRange / 2, new Vector3(1, 2, _weapon.weaponRange), hitboxCenter.rotation);
        foreach (Collider enemy in Enemies) {
            enemy.GetComponent<Enemy>().TakeDamage(_weapon.Damage);
            ManaHandler.Mana += _weapon.ManaPerHit;
        }

    }

    

    private IEnumerator HitCd() // �� ����� �����
    {
        yield return new WaitForSeconds(_weapon.hitCd);
        CanHit = true;
        yield break;
    }
    private IEnumerator AfterComboCd() // �� ����� ���������� ����� � �����
    {
        yield return new WaitForSeconds(_weapon.afterComboCd);
        CanHit = true;
        yield break;
    }



    


}
