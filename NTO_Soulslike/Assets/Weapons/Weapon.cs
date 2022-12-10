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
    [Tooltip("������� ����� ������� � �����")]
    public float hitCd;
    [Tooltip("������� ����� ��������� ����� �� 3-� ������")]
    public float afterComboCd;
    [Tooltip("������������ ���������� ������� ����� ������� ������(���� ����� �� ��� ��� �����, �� ����� ������������)")]
    public float maxComboDelay;
    [Header("���� ��� �����")]
    [Tooltip("�� ���� ��������� ������, �� ����� �������, ��� ����� ��������� ����������� �����.")]
    public EntityType entityType;
    
    
    public virtual void SpecialAbility(WeaponHolder weapon, HitboxShow hitboxShow) { }
    
}
    
