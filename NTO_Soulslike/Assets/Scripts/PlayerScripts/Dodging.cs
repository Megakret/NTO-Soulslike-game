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
        if (Input.GetKeyDown(KeyCode.Q) && PlayerStates.currentState == PlayerStates.States.Idle && CanDodge) // ����� �� ����� ������� �����
        {
            CanDodge = false; // ��������� ������ ����������� ������ �����
            PlayerStates.currentState = PlayerStates.States.Dodge; // ���� ������ ��������� �����
            PlayerStates.IFrame = true; // ������ ������ ������������
            StartCoroutine(Dodge(DodgeSpeed, DodgeTime)); // ��� �����
            StartCoroutine(DodgeCdCount()); // ������� ����������� ������ ����� ����� ��������� �����
            StartCoroutine(PlayerStates.ChangeState(DodgeTime, PlayerStates.States.Idle));// ���������� ��������� �����
            StartCoroutine(IFrameCd());
        }
    }
    public IEnumerator Dodge(float DodgeSpeed, float DodgeTime)
    {

        float StartTime = Time.time;
        while (Time.time < StartTime + DodgeTime) // ������ �� ����� �����
        {
            yield return null;
            controller.Move(Quaternion.Euler(0,gameObject.transform.eulerAngles.y,0) * Vector3.forward * DodgeSpeed * Time.deltaTime);
            

        }
        

        yield break;
        
    }
    private IEnumerator DodgeCdCount() // ���� ������ ����������� ������ ����� ����� ��������� �����
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
