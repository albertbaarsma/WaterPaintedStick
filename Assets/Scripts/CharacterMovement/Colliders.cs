using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public bool playerTouchesDoor = false;

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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            playerTouchesDoor = false;
        }

      /*  if (collision.tag == "Event")
        {
            playerMovement2.enabled = false;
            talkEvents.CatScene2();
        }*/
    }
}
