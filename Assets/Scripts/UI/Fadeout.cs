using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fadeout : MonoBehaviour
{
    public PlayerMovement2 playerMovement2;
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        transition = gameObject.GetComponent<Animator>();
    }

    public void FadeOutAndIn()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        // Play animation
        
        

        // wait
        yield return new WaitForSeconds(transitionTime);

        
    }
}
