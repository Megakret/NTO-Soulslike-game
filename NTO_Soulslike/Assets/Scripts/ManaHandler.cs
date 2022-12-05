using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoCache
{
    private static int mana = 0;
    public GameObject plr;
    public HitboxShow _hitboxShow;
    public Spell[] spells = new Spell[3];
    private KeyCode[] KeyCodes = new KeyCode[] {KeyCode.E, KeyCode.R, KeyCode.T};

    

    public static int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            if(value > 100)
            {
                mana = 100;
            }
            else
            {
                mana = value; 
                Debug.Log($"Mana is: {mana}");
            }
            // «десь можно прописать код дл€ изменени€ шкалы маны.
            
        }
    }

    public override void OnTick()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            
            if (Input.GetKeyDown(KeyCodes[i]) && spells[i] != null && mana > spells[i].manaCost)
            {
                Spell spell = spells[i];
                spell.Activate(this,_hitboxShow);
                Mana -= spell.manaCost;
                
                
            }
        }
    }
    
    

}
