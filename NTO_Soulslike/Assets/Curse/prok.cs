using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prok : MonoCache
{
    public int damageCount = 10;
    public int damageMana = 1;
    /*private void OnCollisionEnter(Collision collision)// � ��� ����� ���� ������ �������� �� ���������
    {
        if(collision.gameObject.tag == "Player")
        {
            Damage.damage(damageMana, collision.gameObject.GetComponent<ManaHandler>());
        }
        Damage.damage(damageCount);// ������ �������� ������� ����� �������� � ������ ����, ���� ��
        

    }
    /*������ �������� ������� ����� �������� � ������ ����, ���� ������ ��������� � ������ manaHandler
     * ����������� ����� ���� ����� Mana(������ ��� ������ � ������ �� ������� ���������� ����� ����) � ������� �����. ������, ����� ��������� ������������ ���������. 
     * ������ ���, ����� �������� ����������, ����� ����� ����� � ���������(������) ���������. � �����������, ����� �� ����� � �����(������) ���������.
     *�� �� �������� ��� ��������� �� ����� ������ ����.
     */

}
