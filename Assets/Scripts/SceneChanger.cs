using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string selectedLevel;

    public void LoadLevel()
    {
        SceneManager.LoadScene(selectedLevel);
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            QuitGame();
        }
    }
}
