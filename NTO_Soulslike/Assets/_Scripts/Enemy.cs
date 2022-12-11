using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoCache
{
    public float HP;
    public bool IsParrying; // Используй, чтобы показать парирует ли моб атаку
    public PlrStun plrStun;
    public void TakeDamage(float damage)
    {
        if (!IsParrying)
        {
            HP -= damage;
            Debug.Log(HP);
        }
        else
        {
            plrStun.GetStun(0.8f);
        }
    }
}
