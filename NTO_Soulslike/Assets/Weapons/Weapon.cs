using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Weapon : ScriptableObject
{
    public string weaponName;
    [Header("Main")]
    public float Damage;
    public int ManaPerHit;
    public float weaponRange;
    [Header("Cooldowns")]
    [Tooltip("Кулдаун между ударами в комбо")]
    public float hitCd;
    [Tooltip("Кулдаун после окончания комбо из 3-х ударов")]
    public float afterComboCd;
    [Tooltip("Максимальный промежуток времени между ударами игрока(Если игрок не бил это время, то комбо сбрасывается)")]
    public float maxComboDelay;
    [Header("Враг или игрок")]
    [Tooltip("На кого цепляется оружие, от этого зависит, как будет выполнена специальная атака.")]
    public EntityType entityType;
    
    
    public virtual void SpecialAbility(WeaponHolder weapon, HitboxShow hitboxShow) { }
    public enum EntityType
    {
        Enemy,
        Player
    }

}
    
