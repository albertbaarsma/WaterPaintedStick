using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManagerNoPlayer : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public UnityEvent onStartDialogue;
    public UnityEvent onEndDialogue;

    public Fadeout fadeout;


    // FIFO collection = First in first out
    // queue of type string
    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Submit") || Input.GetButtonDown("Jump") == true)
        { 
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        onStartDialogue.Invoke();

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
