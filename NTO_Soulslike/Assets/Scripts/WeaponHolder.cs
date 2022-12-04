using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public Weapon _weapon;

    public float comboNum = 0;
    private float prevTick;
    private bool CanHit = true;
    void Start()
    {
        prevTick = Time.time;
    }

    // Update is called once per frame
    void Update()
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
            _weapon.SpecialAbility();
            StartCoroutine(AfterComboCd());
            comboNum = 0;

        }
        else
        {
            StartCoroutine(HitCd());
            
            
        }
        Debug.Log("Hit");
        CanHit = false;
        prevTick = Time.time;

        


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
