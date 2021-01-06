using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public UnityEvent onEndDialogue;

    public Animator animator;
    public Fadeout fadeout;


    // FIFO collection = First in first out
    // queue of type string
    private Queue<string> sentences;

    public GameObject player;
    PlayerMovement2 playerMovement2;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        playerMovement2 = player.GetComponent<PlayerMovement2>();
    }

    private void Update()
    {
        if (playerMovement2.someoneIsTalking == true)
        {
            if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump") == true)
            {
                DisplayNextSentence();
            }
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        playerMovement2.someoneIsTalking = true;
        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            // adding to sentence queu
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
                return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        playerMovement2.someoneIsTalking = false;
        fadeout.transition.SetBool("Event", false);
        StartCoroutine(EventAfterFade());
    }

    IEnumerator EventAfterFade()
    {
        fadeout.transition.SetTrigger("Start");
        fadeout.transition.SetBool("Event", false);

        yield return new WaitForSeconds(1);
        fadeout.transition.SetBool("Event", true);
        onEndDialogue.Invoke();
    }
}
