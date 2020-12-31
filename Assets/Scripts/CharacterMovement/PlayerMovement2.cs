using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;
    public bool someoneIsTalking = false;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    

    // Update is called once per frame
    void Update()
    {
        

        if (someoneIsTalking == true)
        {
            animator.SetBool("IsJumping", false);
            animator.SetBool("Crouch", false);
        } else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

            if (Input.GetButtonDown("Jump"))
            {
                jump = true;
                animator.SetBool("IsJumping", true);
            }
            if (Input.GetButtonDown("Crouch"))
            {
                crouch = true;
            }
            else if (Input.GetButtonUp("Crouch"))
            {
                crouch = false;
            }
        }
    }

    private void FixedUpdate()
    {
        // move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
            animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
            animator.SetBool("IsCrouching", isCrouching);
    }
}
