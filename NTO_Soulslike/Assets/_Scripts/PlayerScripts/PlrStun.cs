using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlrStun : MonoBehaviour
{
    public GameObject stunParticles;
    public Transform Head; // ����� ����� �������� ����� ���� ���������� ���������� ������, � ���� ��� ����� ���� hitboxCenter ������.
    public void GetStun(float duration)
    {
        PlayerStates.currentState = PlayerStates.States.Stunned;
        GameObject stunParticle = Instantiate(stunParticles, Head.position, Quaternion.identity);
        StartCoroutine(PlayerStates.ChangeState(duration, PlayerStates.States.Idle));
        StartCoroutine(ParticleCooldown(duration,stunParticle));
    }
    private IEnumerator ParticleCooldown(float duration, GameObject stunParticle)
    {
        yield return new WaitForSeconds(duration);
        Destroy(stunParticle);
        yield break;
        

    }
    
}
