using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string selectedLevel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(selectedLevel);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
