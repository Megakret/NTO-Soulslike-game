using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodging : MonoCache
{
    public CharacterController controller;
    public ThirdPersonController personController;
    

    public float DodgeSpeed;
    public float DodgeTime;
    public float DodgeCd;
    public float IFramesTime;
    private bool CanDodge = true;
    
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStates.currentState == PlayerStates.States.Idle && CanDodge) // Может ли игрок сделать рывок
        {
            CanDodge = false; // Выключает игроку возможность делать рывок
            PlayerStates.currentState = PlayerStates.States.Dodge; // Дает игроку состояния рывок
            PlayerStates.IFrame = true; // Выдать игроку неуязвимость
            StartCoroutine(Dodge()); // Сам рывок
            StartCoroutine(DodgeCdCount()); // Вернуть возможность делать рывок через некоторое время
            StartCoroutine(PlayerStates.ChangeState(DodgeTime, PlayerStates.States.Idle));// Возвращает состояние покоя
            StartCoroutine(IFrameCd());
        }
    }
    private IEnumerator Dodge()
    {

        float StartTime = Time.time;
        while (Time.time < StartTime + DodgeTime) // Отсчет до конца рывка
        {
            yield return null;
            controller.Move(personController.movDir.normalized * DodgeSpeed * Time.deltaTime);
            

        }
        

        yield break;
        
    }
    private IEnumerator DodgeCdCount() // Дают игроку возможность делать рывок через некоторое время
    {
        yield return new WaitForSeconds(DodgeCd);
        CanDodge = true;
        yield break;
    }
    private IEnumerator IFrameCd()
    {
        yield return new WaitForSeconds(IFramesTime);
        PlayerStates.IFrame = false;
        yield break;
    }
}
