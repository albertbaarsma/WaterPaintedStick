using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkEvents : MonoBehaviour
{
    public GameObject conversationTrigger;
    
    DialogueTrigger dialogueTrigger;

    private void Start()
    {
        dialogueTrigger = conversationTrigger.GetComponent<DialogueTrigger>();
    }

    public void CatScene2()
    {
        dialogueTrigger.TriggerDialogue();
        Destroy(conversationTrigger);
    }
}
