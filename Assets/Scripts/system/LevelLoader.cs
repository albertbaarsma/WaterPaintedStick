﻿using System.Collections;
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

    public void LoadPreviousLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
    }

    public void LoadLevelByIndex(int levelIndex)
    {
        Time.timeScale = 1f;
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void ReloadLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        // Play animation
        transition.SetTrigger("Start");
        transition.SetBool("Event", false);

        // wait
        yield return new WaitForSeconds(transitionTime);

        // load scene
        SceneManager.LoadScene(levelIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
