using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaHandler : MonoCache
{
    private static int mana = 0;
    public Transform plrCenter;
    public HitboxShow _hitboxShow;
    public Spell[] spells = new Spell[3];
    public Bar ManaBar;
    public int MaxMana;
    private KeyCode[] KeyCodes = new KeyCode[] {KeyCode.E, KeyCode.R, KeyCode.T};

    

    public int Mana
    {
        get
        {
            return mana;
        }
        set
        {
            if(value > 100)
            {
                mana = MaxMana;
            }
            else
            {
                mana = value; 
                //Debug.Log($"Mana is: {mana}");
            }
            // «десь можно прописать код дл€ изменени€ шкалы маны.
            ManaBar.ChangeSlider((double)mana/MaxMana);
            
        }
    }

    public override void OnTick()
    {
        for (int i = 0; i < spells.Length; i++)
        {
            
            if (Input.GetKeyDown(KeyCodes[i]) && spells[i] != null && mana > spells[i].manaCost && PlayerStates.currentState == PlayerStates.States.Idle)
            {
                PlayerStates.currentState = PlayerStates.States.Attack;
                
                Spell spell = spells[i];
                StartCoroutine(PlayerStates.ChangeState(spell.microCd,PlayerStates.States.Idle));
                spell.Activate(this,_hitboxShow, plrCenter);
                Mana -= spell.manaCost;
                
                
            }
        }
    }
    
    

}
