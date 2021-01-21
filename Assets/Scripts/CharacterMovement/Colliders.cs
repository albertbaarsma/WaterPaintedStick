using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colliders : MonoBehaviour
{
    public bool playerTouchesDoor = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            playerTouchesDoor = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Door")
        {
            playerTouchesDoor = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Pebble")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.1 || collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.1)
            {
                FindObjectOfType<AudioManager>().Play("Pebble");
            }
        }

        if (collision.gameObject.tag == "Rock")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0.1 || collision.gameObject.GetComponent<Rigidbody2D>().velocity.y > 0.1)
            {
                FindObjectOfType<AudioManager>().Play("Rock");
            }
        }
    }
}
