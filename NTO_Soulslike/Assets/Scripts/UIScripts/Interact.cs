using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoCache
{
    public bool CanInteract = false;
    public DialogueEditor.NPCConversation conversation;
    public override void OnTick()
    {
        if (Input.GetKeyDown(KeyCode.F) && CanInteract)
        {
            DialogueEditor.ConversationManager.Instance.StartConversation(conversation);
            PlayerStates.currentState = PlayerStates.States.Stunned;
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Dialogue")
        {
            Cursor.lockState = CursorLockMode.None;
            conversation = other.gameObject.GetComponent<DialogueEditor.NPCConversation>();
            CanInteract = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Dialogue")
        {
            CanInteract = false;
        }
    }
}
