using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrStun : MonoBehaviour
{
    public PlayerStates playerStates;
    public GameObject stunParticles;
    public Transform Head; // ����� ����� �������� ����� ���� ���������� ���������� ������, � ���� ��� ����� ���� hitboxCenter ������.
    public void GetStun(float duration)
    {
        Debug.Log("Stun");
        playerStates.ChangeStateFunc(duration);
        playerStates.currentState = PlayerStates.States.Stunned;
        GameObject stunParticle = Instantiate(stunParticles, Head.position, Quaternion.identity);
        stunParticle.GetComponent<ParticleSystem>().Play();
        playerStates.Stop = true;
        StartCoroutine(StunCooldown(duration,stunParticle));
    }
    private IEnumerator StunCooldown(float duration, GameObject stunParticle)
    {
        yield return new WaitForSeconds(duration);
        playerStates.currentState = PlayerStates.States.Idle;
        Destroy(stunParticle);
        yield break;
        

    }
    
}
