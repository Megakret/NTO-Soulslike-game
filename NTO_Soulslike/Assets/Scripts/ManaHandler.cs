using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoCache
{
    private static int mana;
    public GameObject plr;
    public Spell[] spells = new Spell[3];
    private KeyCode[] KeyCodes = new KeyCode[] {KeyCode.E, KeyCode.R, KeyCode.T};

    

    public int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            mana = value; // «десь можно прописать код дл€ изменени€ шкалы маны.
        }
    }

    public override void OnTick()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            
            if (Input.GetKeyDown(KeyCodes[i]) && spells[i] != null)
            {
                Spell spell = spells[i];
                spell.Activate(plr);
                
                
            }
        }
    }
    
    

}
