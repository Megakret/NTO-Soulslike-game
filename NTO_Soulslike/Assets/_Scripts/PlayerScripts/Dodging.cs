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
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStates.currentState == PlayerStates.States.Idle && CanDodge) // Ìîæåò ëè èãðîê ñäåëàòü ðûâîê
        {
            CanDodge = false; // Âûêëþ÷àåò èãðîêó âîçìîæíîñòü äåëàòü ðûâîê
            PlayerStates.currentState = PlayerStates.States.Dodge; // Äàåò èãðîêó ñîñòîÿíèÿ ðûâîê
            PlayerStates.IFrame = true; // Âûäàòü èãðîêó íåóÿçâèìîñòü

            StartCoroutine(Dodge(DodgeSpeed, DodgeTime)); // Ñàì ðûâîê

            StartCoroutine(DodgeCdCount()); // Âåðíóòü âîçìîæíîñòü äåëàòü ðûâîê ÷åðåç íåêîòîðîå âðåìÿ
            StartCoroutine(PlayerStates.ChangeState(DodgeTime, PlayerStates.States.Idle));// Âîçâðàùàåò ñîñòîÿíèå ïîêîÿ
            StartCoroutine(IFrameCd());
        }
    }
    public IEnumerator Dodge(float DodgeSpeed, float DodgeTime)
    {

        float StartTime = Time.time;
        while (Time.time < StartTime + DodgeTime) // Îòñ÷åò äî êîíöà ðûâêà
        {
            yield return null;
            controller.Move(Quaternion.Euler(0,gameObject.transform.eulerAngles.y,0) * Vector3.forward * DodgeSpeed * Time.deltaTime);
            

        }
        

        yield break;
        
    }
    private IEnumerator DodgeCdCount() // Äàþò èãðîêó âîçìîæíîñòü äåëàòü ðûâîê ÷åðåç íåêîòîðîå âðåìÿ
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
