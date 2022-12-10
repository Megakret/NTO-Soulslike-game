using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoCache
{
    public PlayerStates playerStates;
    public PlrStun plrStun;
    public float parryWindow;
    [Tooltip("Время оглушения, которое игрок получает, если игрок не парировал не одну атаку.")]
    public float StunTime;
    private bool DidParry; // Проверяет спарировал ли игрок чью то атаку
    public float EnemyStunTime;
    public override void OnTick()
    {
        if (Input.GetButtonDown("Fire2") && playerStates.currentState == PlayerStates.States.Idle)
        {
            ParryMake();
        }
        
    }
    private void ParryMake()
    {
        playerStates.currentState = PlayerStates.States.Parry;
        StartCoroutine(ParryCoroutine());
        
    }
    public void SuccesfullParry()
    {
        DidParry = true;
        playerStates.currentState = PlayerStates.States.Idle;
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
            plrStun.GetStun(StunTime);
        }
        yield break;
    }
    
}
