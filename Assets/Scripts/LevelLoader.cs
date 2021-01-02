using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public static LevelLoader instance;

    public GameObject player;
    private Colliders colliders;
    PlayerMovement2 playerMovement2;

    private void Start()
    {
        colliders = player.GetComponent<Colliders>();
        playerMovement2 = player.GetComponent<PlayerMovement2>();
    }

    void Update()
    {
        // GameObject.FindGameObjectWithTag("Player") refers to player object. There is probably a better way.
        if (colliders.playerTouchesDoor == true)
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");

        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }
}
