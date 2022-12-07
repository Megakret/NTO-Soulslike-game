using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    private int hp;
    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            if (value <= 0)
            {
                Dead();
            }
            else if (value <= 100)
            {
                hp = value; // «десь можно прописать изменение шкалы здоровь€
            }
            else
            {
                hp = 100;
            }
            Debug.Log(value);    
        }
    }
    private void Awake()
    {
        hp = 10;
    }
    private static void Dead()
    {

    }
    
}
