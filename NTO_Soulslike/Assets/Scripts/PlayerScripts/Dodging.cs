using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodging : MonoCache
{
    public CharacterController controller;
    public ThirdPersonController personController;
    

    public float DodgeSpeed;
    public float DodgeTime;
    
    
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStates.currentState == PlayerStates.States.Idle)
        {
            StartCoroutine(Dodge());
            PlayerStates.currentState = PlayerStates.States.Dodge;
            PlayerStates.IFrame = true;
            StartCoroutine(PlayerStates.ChangeState(DodgeTime, PlayerStates.States.Idle));

        }
    }
    private IEnumerator Dodge()
    {
        float StartTime = Time.time;
        while (Time.time < StartTime + DodgeTime)
        {
            yield return null;
            controller.Move(personController.movDir.normalized * DodgeSpeed * Time.deltaTime);
            Debug.Log(personController.movDir.normalized);

        }
        PlayerStates.IFrame = false;

        yield break;
        
    }
}
