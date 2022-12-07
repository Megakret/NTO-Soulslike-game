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
    private bool CanDodge;
    
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStates.currentState == PlayerStates.States.Idle && CanDodge) // ����� �� ����� ������� �����
        {
            CanDodge = false; // ��������� ������ ����������� ������ �����
            PlayerStates.currentState = PlayerStates.States.Dodge; // ���� ������ ��������� �����
            PlayerStates.IFrame = true; // ������ ������ ������������
            StartCoroutine(Dodge()); // ��� �����
            StartCoroutine(DodgeCdCount()); // ������� ����������� ������ ����� ����� ��������� �����
            StartCoroutine(PlayerStates.ChangeState(DodgeTime, PlayerStates.States.Idle));// ���������� ��������� �����

        }
    }
    private IEnumerator Dodge()
    {

        float StartTime = Time.time;
        while (Time.time < StartTime + DodgeTime) // ������ �� ����� �����
        {
            yield return null;
            controller.Move(personController.movDir.normalized * DodgeSpeed * Time.deltaTime);
            

        }
        PlayerStates.IFrame = false;

        yield break;
        
    }
    private IEnumerator DodgeCdCount() // ���� ������ ����������� ������ ����� ����� ��������� �����
    {
        yield return new WaitForSeconds(DodgeCd);
        CanDodge = true;
        yield break;
    }
}
