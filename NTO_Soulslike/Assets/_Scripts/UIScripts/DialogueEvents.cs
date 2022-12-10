using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class DialogueEvents : MonoBehaviour
{
    public PlayerStates playerStates;
    private void OnEnable()
    {
        ConversationManager.OnConversationStarted += BeginDialogue;
        ConversationManager.OnConversationEnded += EndDialogue;
    }
    private void OnDisable()
    {
        ConversationManager.OnConversationStarted -= BeginDialogue;
        ConversationManager.OnConversationEnded -= EndDialogue;
    }
    public void BeginDialogue()
    {
        Cursor.lockState = CursorLockMode.None;
        playerStates.currentState = PlayerStates.States.Stunned;
    }
    public void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerStates.currentState = PlayerStates.States.Idle;
    }
}
