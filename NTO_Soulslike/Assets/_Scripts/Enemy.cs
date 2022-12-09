using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float HP;
    public void TakeDamage(float damage)
    {
        HP -= damage;
        //Debug.Log(HP);
    }
}
