using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerStates : MonoBehaviour
{
    public bool IFrame;
    public bool Stop;
    public States currentState;
    
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
    public void ChangeStateFunc(float duration)
    {
        if (prevDuration - tick < duration)
        {
            
            StartCoroutine(ChangeState(duration));
        }

    }
    public IEnumerator ChangeState(float duration) //Смена состояния игрока через некоторое время
    {
            yield return null;
        
            prevDuration = duration;
            while (tick <= duration)
            {
                
                yield return null;
                tick += Time.deltaTime;
            }
        if (currentState != States.Stunned)
        {
                currentState = States.Idle;
                prevDuration = 0;
            
                tick = 0;
        }
                

       
       yield break;
    }
    
}
