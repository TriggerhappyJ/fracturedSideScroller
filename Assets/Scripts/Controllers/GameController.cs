using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;
    private bool gamePaused;
    
    // Start is called before the first frame update
    void Start()
    {
        TimerController.instance.StartTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gamePaused)
        {
            PauseGame();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnPauseGame();
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        gamePaused = true;
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        gamePaused = false;
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game!");
    }
}
