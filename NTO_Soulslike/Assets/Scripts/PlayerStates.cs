using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerStates : MonoBehaviour
{
    public static bool IFrame;
    public static States currentState;
    public enum States
    {
        Idle,
        Parry,
        Attack,
        Dodge,
        Stunned,
        Healing
    }
    
}
