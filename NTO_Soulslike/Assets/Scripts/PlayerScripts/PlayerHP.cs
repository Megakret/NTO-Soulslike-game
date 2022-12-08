using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoCache
{
    private int hp;
    public int MaxHP;
    public Bar HealthBar;
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
                hp = 0;
            }
            else if (value <= MaxHP)
            {
                hp = value; // «десь можно прописать изменение шкалы здоровь€
            }
            else
            {
                hp = MaxHP;
            }
            HealthBar.ChangeSlider((double) hp/MaxHP);
            Debug.Log(value);    
        }
    }
    private void Awake()
    {
        hp = MaxHP;
    }
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            HP -= 10;
        }
    }

}
