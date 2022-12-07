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
        
        if (Input.GetKey(KeyCode.H) && CanHeal && HealCount > 0 && (PlayerStates.currentState == PlayerStates.States.Idle || PlayerStates.currentState == PlayerStates.States.Healing))
        {
            Heal();
            PlayerStates.currentState = PlayerStates.States.Healing;
            
        }
        else
        {
            
            TickTime = 0;
            if(PlayerStates.currentState == PlayerStates.States.Healing)
            {
                PlayerStates.currentState = PlayerStates.States.Idle;
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
