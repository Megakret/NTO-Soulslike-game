using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : ScriptableObject
{
    public string weaponName;
    public int Damage;
    public float hitCd;
    public float afterComboCd;
    public float weaponRange;
    public float maxComboDelay;

    public virtual void SpecialAbility() { }
}
