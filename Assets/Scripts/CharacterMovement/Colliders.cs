using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public bool playerTouchesDoor = false;
    public Animator transition;
    public float transitionTime = 1f;

    // public TalkEvents talkEvents;

    PlayerMovement2 playerMovement2;

    private void Start()
    {
        playerMovement2 = gameObject.GetComponent<PlayerMovement2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            Debug.Log("player touches door");
            playerTouchesDoor = true;
        }
        if (collision.tag == "Event")
        {
            Fadeout();
            collision.GetComponent<DialogueTrigger>().TriggerDialogue();
            Destroy(collision);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            playerTouchesDoor = false;
        }

        
    }

    public void Fadeout()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        // Play animation
        transition.SetBool("Event", true);
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        playerMovement2.someoneIsTalking = true;
        playerMovement2.TeleportCharacter(1.57f, -2.16f);
    }
}
