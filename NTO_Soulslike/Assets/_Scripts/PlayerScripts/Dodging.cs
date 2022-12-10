using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dodging : MonoCache
{
    public CharacterController controller;
    public ThirdPersonController personController;
    public PlayerStates playerStates;
    public AnimatorScript animatorScript;

    public float DodgeSpeed;
    public float DodgeTime;
    public float DodgeCd;
    public float IFramesTime;
    private bool CanDodge = true;
    
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.Q) && playerStates.currentState == PlayerStates.States.Idle && CanDodge) // Ìîæåò ëè èãðîê ñäåëàòü ðûâîê
        {
            CanDodge = false; // Âûêëþ÷àåò èãðîêó âîçìîæíîñòü äåëàòü ðûâîê
            playerStates.currentState = PlayerStates.States.Dodge; // Äàåò èãðîêó ñîñòîÿíèÿ ðûâîê
            playerStates.IFrame = true; // Âûäàòü èãðîêó íåóÿçâèìîñòü

            StartCoroutine(Dodge(DodgeSpeed, DodgeTime)); // Ñàì ðûâîê
            animatorScript.Dodge();
            StartCoroutine(DodgeCdCount()); // Âåðíóòü âîçìîæíîñòü äåëàòü ðûâîê ÷åðåç íåêîòîðîå âðåìÿ
            playerStates.ChangeStateFunc(DodgeTime);// Âîçâðàùàåò ñîñòîÿíèå ïîêîÿ
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
        playerStates.IFrame = false;
        yield break;
    }
}
