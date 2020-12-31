using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    /* public GameObject player;

     private void OnCollisionEnter2D(Collision2D collision)
     {
         Debug.Log("collider does something");

         if (collision.collider.tag == "layer")
         {
             Debug.Log("player touches door");
         }
     }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter collision");

    }
}
