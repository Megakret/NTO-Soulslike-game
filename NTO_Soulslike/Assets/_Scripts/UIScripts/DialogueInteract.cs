using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class DialogueInteract : Interactable
{
    public NPCConversation conversation;
    public override void Interacting(GameObject plr)
    {
        ConversationManager.Instance.StartConversation(conversation);
    }
}
