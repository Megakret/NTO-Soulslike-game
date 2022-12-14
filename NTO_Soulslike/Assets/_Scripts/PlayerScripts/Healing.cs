using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class Healing : MonoCache
{
    public PlayerStates playerStates;
    public int healCount;
    [Header("Healing Properties")]
    public float HealTime;
    public int HPPerHeal;
    public PlayerHP playerHP;
    [Header("PancakeUI")]
    public Text text;
    private float TickTime;
    private bool CanHeal;
    public int HealCount
    {
        get
        {
            return healCount;
        }
        set
        {
            if(value >= 10)
            {
                healCount = 10;
            }
            else
            {
                healCount = value;
                
            }
            text.text = Convert.ToString(healCount);

        }
    }
    private void Awake()
    {
        HealCount = 0;
        CanHeal = true;
    }
    public override void OnTick()
    {
        
        if (Input.GetKey(KeyCode.H) && CanHeal && healCount > 0 && (playerStates.currentState == PlayerStates.States.Idle || playerStates.currentState == PlayerStates.States.Healing))
        {
            Heal();
            playerStates.currentState = PlayerStates.States.Healing;
            
        }
        else
        {
            
            TickTime = 0;
            if(playerStates.currentState == PlayerStates.States.Healing)
            {
                playerStates.currentState = PlayerStates.States.Idle;
            }
        }

    }
    private void Heal()
    {
        TickTime += Time.deltaTime;
        Debug.Log("Healing");
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
