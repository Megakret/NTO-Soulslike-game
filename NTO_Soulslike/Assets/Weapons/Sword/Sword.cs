using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Sword : Weapon
{
    public override void SpecialAbility() // ����� ��� ��������� �������� �� 3 �����
    {
        Debug.Log("Final Hit");
        
    }
}
