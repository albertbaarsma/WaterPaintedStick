using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent eventOnPlayerTouch;
    public bool triggersOnce = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            eventOnPlayerTouch.Invoke();
            if (triggersOnce)
            {
                Destroy(gameObject);
            }
        }
    }
}
