using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoCache
{
    public PlayerStates playerStates;
    public PlrStun plrStun;
    public float parryWindow;
    [Tooltip("����� ���������, ������� ����� ��������, ���� ����� �� ��������� �� ���� �����.")]
    public float StunTime;
    private bool DidParry; // ��������� ���������� �� ����� ��� �� �����
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
