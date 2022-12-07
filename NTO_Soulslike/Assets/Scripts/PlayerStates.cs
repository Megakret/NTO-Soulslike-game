using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerStates : MonoBehaviour
{
    public static bool IFrame;
    public static States currentState;
    //��� ���������� ��������� ��������� ������
    private static float tick = 0; // �����, ������� ������������� �� ������ ����� ���������
    private static float prevDuration = 0; // ������������ ���������� ����� ���������
    public enum States
    {
        Idle,
        Parry,
        Attack,
        Dodge,
        Stunned,
        Healing
    }
    public static IEnumerator ChangeState(float duration, States state) //����� ��������� ������ ����� ��������� �����
    {
       if(prevDuration - tick < duration)
       {
            prevDuration = duration;
            while (tick <= duration)
            {
                yield return null;
                tick += Time.deltaTime;
            }
            currentState = state;
            prevDuration = 0;
            
            tick = 0;

       }
       yield break;
    }
    
}
