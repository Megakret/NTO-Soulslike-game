using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class Sword : Weapon
{
    public override void SpecialAbility() // Здесь код особенной способки на 3 ударе
    {
        Debug.Log("Final Hit");
        
    }
}
