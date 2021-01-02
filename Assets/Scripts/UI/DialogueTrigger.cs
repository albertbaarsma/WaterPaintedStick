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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            StartCoroutine(WaitBeforeShow(collision.gameObject));
        }
    }

    IEnumerator WaitBeforeShow(GameObject player)
    {
        fadeout.transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);
        fadeout.transition.SetBool("Event", true);
        // fadeout.transition.SetTrigger("Start");
        TriggerDialogue();

        playerMovement = player.GetComponent<PlayerMovement2>();

        playerMovement.someoneIsTalking = true;
        playerMovement.TeleportCharacter(1.57f, -2.16f);

        Destroy(gameObject);

    }
}
