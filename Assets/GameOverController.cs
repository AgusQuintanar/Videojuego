using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOverController : MonoBehaviour
{
    [SerializeField] Button playAgainButton;
    [SerializeField] Button homeButton;

    void Start()
    {
        playAgainButton.onClick.AddListener(PlayAgain);
        homeButton.onClick.AddListener(BackToHome);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

    private void BackToHome()
    {
        SceneManager.LoadScene(0);
    }
}
