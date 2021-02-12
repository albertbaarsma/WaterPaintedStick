using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Fadeout fadeout;
    private PlayerMovement2 playerMovement;

    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMovement = collision.gameObject.GetComponent<PlayerMovement2>();
            StartCoroutine(WaitBeforeShow());
        }
    }

    IEnumerator WaitBeforeShow()
    {
        fadeout.transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        fadeout.transition.SetBool("Event", true);
        TriggerDialogue();

        // cat sound -- should find better solution for this to make code more dynamic
        FindObjectOfType<AudioManager>().Play("Cat");
        
        playerMovement.someoneIsTalking = true;
        playerMovement.TeleportCharacter(gameObject.transform.position.x, gameObject.transform.position.y);

        Destroy(gameObject);

    }
}
