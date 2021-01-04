using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public Fadeout fadeout;
    private PlayerMovement2 playerMovement;

    public float teleportPosX = 1.57f;
    public float teleportPosY = -2.16f;


    public void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnCollisionEnter2D(Collision2D collision)
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

        playerMovement.someoneIsTalking = true;
        playerMovement.TeleportCharacter(teleportPosX, teleportPosY);

        Destroy(gameObject);

    }
}
