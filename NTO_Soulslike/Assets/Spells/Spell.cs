using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : ScriptableObject
{
    public string Name;
    public int manaCost;
    public float microCd;
    public virtual void Activate(ManaHandler manaHandler, HitboxShow hitboxShow, Transform plrCenter) { }
}
