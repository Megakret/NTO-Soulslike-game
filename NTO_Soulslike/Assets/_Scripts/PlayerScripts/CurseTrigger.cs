using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseTrigger : MonoBehaviour
{
    public ManaHandler mana;
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "CurseStart")
        {
            Damage damage = other.gameObject.transform.parent.GetComponent<Damage>();
            damage.StartCurse(mana);
        }else if(other.gameObject.tag == "CurseEnd")
        {
            Damage damage = other.gameObject.transform.parent.GetComponent<Damage>();
            damage.BreakCurse();
        }
    }
}
