using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoCache
{
    // Start is called before the first frame update
    public Weapon _weapon;
    public Transform hitboxCenter;
    public LayerMask WhatIsEnemies;
   

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
    public void Click()
    {
        float nowTick = Time.time;
        if(nowTick - prevTick >= _weapon.maxComboDelay)
        {
            comboNum = 0;
            prevTick = Time.time;
            StartCoroutine(AfterComboCd());

        }
        comboNum++;
        
        if(comboNum == 3)
        {
            _weapon.SpecialAbility(this);
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
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.matrix = Matrix4x4.TRS(hitboxCenter.position, hitboxCenter.rotation, hitboxCenter.localScale);
        Gizmos.DrawCube(Vector3.zero, new Vector3(0, 2, _weapon.weaponRange));

    }
    public void Attack()
    {
        Collider[] Enemies = Physics.OverlapBox(hitboxCenter.position, new Vector3(0, 2, _weapon.weaponRange), hitboxCenter.rotation, WhatIsEnemies);
        
        foreach (Collider enemy in Enemies) {
            enemy.GetComponent<Enemy>().TakeDamage(_weapon.Damage);
            
        }

    }
    private IEnumerator HitCd()
    {
        yield return new WaitForSeconds(_weapon.hitCd);
        CanHit = true;
        yield break;
    }
    private IEnumerator AfterComboCd()
    {
        yield return new WaitForSeconds(_weapon.afterComboCd);
        CanHit = true;
        yield break;
    }

    


}
