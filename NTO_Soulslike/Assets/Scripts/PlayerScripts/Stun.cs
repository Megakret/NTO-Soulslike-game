using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stun : MonoBehaviour
{
    private string Tag;
    private void Awake()
    {
        Tag = gameObject.tag;
    }
    public void GetStun(float duration)
    {
        if(Tag == "Player")
        {
            PlayerStates.currentState = PlayerStates.States.Stunned;
        }
        else if(Tag == "Enemy")
        {

        }
        
    }
}
