using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoCache
{
    public float HP;
    public bool IsParrying; // ���������, ����� �������� �������� �� ��� �����
    public void TakeDamage(float damage)
    {
        HP -= damage;
        //Debug.Log(HP);
    }
}
