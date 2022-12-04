using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log(HP);
    }
}
