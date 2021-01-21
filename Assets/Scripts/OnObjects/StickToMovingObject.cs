using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickToMovingObject : MonoBehaviour
{
    public Vector3 velocity;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.collider.transform.SetParent(null);
            collision.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
