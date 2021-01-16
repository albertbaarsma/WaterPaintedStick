using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTouch : MonoBehaviour
{
    public Vector3 velocity;

    public bool moving = true;
    private Vector3 startingPos;
    private Vector3 returnPos;
    public Vector3 desiredMoveTarget;

    bool goBack = false;

    private void Start()
    {
        startingPos = transform.position;
        returnPos = startingPos + desiredMoveTarget;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            moving = true;
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
        }
    }

    private void FixedUpdate()
    {
        if (true)
        {
            if (transform.position.x >= returnPos.x && transform.position.y >= returnPos.y)
            {
                goBack = true;
            }
            if (transform.position.x <= startingPos.x && transform.position.y <= startingPos.y)
            {
                goBack = false;
            }

            if (goBack == true)
            {
                transform.position -= (velocity * Time.deltaTime);
            } else
            {
                transform.position += (velocity * Time.deltaTime);
            }
        }
    }
}
