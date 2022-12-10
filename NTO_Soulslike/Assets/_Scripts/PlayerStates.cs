using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerStates : MonoBehaviour
{
    public static bool IFrame;
    public static bool CanAttack = true;
    public static States currentState;
    //Для приоритета изменения состояния игрока
    private static float tick = 0; // Время, которое отсчитывается от начала смены состояния
    private static float prevDuration = 0; // Длительность предыдущей смены состояния
    public enum States
    {
        Idle,
        Parry,
        Attack,
        Dodge,
        Stunned,
        Healing
    }
    public static IEnumerator ChangeState(float duration, States state) //Смена состояния игрока через некоторое время
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
