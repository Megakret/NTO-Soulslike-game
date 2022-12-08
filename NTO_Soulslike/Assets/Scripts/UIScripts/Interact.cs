using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class Interact : MonoCache
{
    public bool CanInteract = false;
    public Interactable interactable;
    
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanInteract)
        {
            interactable.Interacting(gameObject);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            interactable = other.gameObject.GetComponent<Interactable>();
            interactable.Near();
            CanInteract = true;
        }
    }
    

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Interactable")
        {
            interactable.Far();
            interactable = null;
            CanInteract = false;
        }
    }
    public virtual void Interacting()
    {

    }
    
}
