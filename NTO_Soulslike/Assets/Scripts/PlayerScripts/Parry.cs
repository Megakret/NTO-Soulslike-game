using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoCache
{
    public float parryWindow;
    [Tooltip("����� ���������, ������� ����� ��������, ���� ����� �� ��������� �� ���� �����.")]
    public float StunTime;
    private bool DidParry; // ��������� ���������� �� ����� ��� �� �����
    public override void OnTick()
    {
        if (Input.GetButtonDown("Fire2") && PlayerStates.currentState == PlayerStates.States.Idle)
        {
            ParryMake();
        }
        if (Input.GetKeyDown(KeyCode.L) && PlayerStates.currentState == PlayerStates.States.Parry)
        {
            SuccesfullParry();
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
