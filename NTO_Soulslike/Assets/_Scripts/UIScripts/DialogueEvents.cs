using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;
public class DialogueEvents : MonoBehaviour
{
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
        PlayerStates.currentState = PlayerStates.States.Stunned;
    }
    public void EndDialogue()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerStates.currentState = PlayerStates.States.Idle;
    }
}
