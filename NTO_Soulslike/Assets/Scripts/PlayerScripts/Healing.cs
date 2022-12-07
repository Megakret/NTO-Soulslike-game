using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoCache
{
    public int HealCount;
    [Header("Healing Properties")]
    public float HealTime;
    public int HPPerHeal;
    public PlayerHP playerHP;
   
    private float TickTime;
    private bool CanHeal;

    private void Awake()
    {
        HealCount = 10;
        CanHeal = true;
    }
    public override void OnTick()
    {
        
        if (Input.GetKey(KeyCode.H) && CanHeal && HealCount > 0)
        {
            Heal();
            
        }
        else
        {
            TickTime = 0;
        }

    }
    private void Heal()
    {
        TickTime += Time.deltaTime;
        if (TickTime >= HealTime)
        {
            playerHP.HP += HPPerHeal;
            CanHeal = false;
            HealCount -= 1;
            StartCoroutine(MicroCd());
            
        }
    }
    private IEnumerator MicroCd()
    {
        yield return new WaitForSeconds(.5f);
        CanHeal = true;
        yield break;
        
    }
    public void StopHeal()
    {
        TickTime = 0;
        CanHeal = false;
        
    }

    
}
