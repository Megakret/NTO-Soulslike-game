using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoCache
{
    public float parryWindow;
    [Tooltip("Время оглушения, которое игрок получает, если игрок не парировал не одну атаку.")]
    public float StunTime;
    private bool DidParry; // Проверяет спарировал ли игрок чью то атаку
    public float EnemyStunTime;

    public override void OnTick()
    {
        if (Input.GetButtonDown("Fire2") && PlayerStates.currentState == PlayerStates.States.Idle)
        {
            ParryMake();
        }
        
    }
    private void ParryMake()
    {
        PlayerStates.currentState = PlayerStates.States.Parry;
        StartCoroutine(ParryCoroutine());
        
    }
    public void SuccesfullParry()
    {
        DidParry = true;
        PlayerStates.currentState = PlayerStates.States.Idle;
        StopCoroutine(ParryCoroutine());
    }
    private IEnumerator ParryCoroutine()
    {
        yield return new WaitForSeconds(parryWindow);
        if (DidParry)
        {
            DidParry = false;
            
        }
        else
        {
            PlayerStates.currentState = PlayerStates.States.Stunned;
            StartCoroutine(PlayerStates.ChangeState(StunTime, PlayerStates.States.Idle));
        }
        yield break;
    }
    
}
