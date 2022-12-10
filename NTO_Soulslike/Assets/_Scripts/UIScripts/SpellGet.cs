using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellGet : Interactable
{
    public Spell spell;
    public override void Interacting(GameObject plr)
    {
        ManaHandler manaHandler = plr.GetComponent<ManaHandler>();
        int index = LastSpellIndex(manaHandler.spells);
        if(index != -1)
        {
            manaHandler.spells[index] = spell;
            Destroy(gameObject);
        }
    }
    public int LastSpellIndex(Spell[] spells)
    {
        for(int i = 0; i < spells.Length; i++)
        {
            if(spells[i] == null)
            {
                return i;
                
            }
        }
        return -1;
    }
}
