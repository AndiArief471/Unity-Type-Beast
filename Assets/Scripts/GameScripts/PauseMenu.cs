using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Timers;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Typer typer = null;
    private bool isAlreadyExecuted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        // when called the pauseMenu is set to false
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if pause menu is called then set the boolean to false
        if(typer.executePausePage() == false)
        {
            isAlreadyExecuted = false;
        }
        if (typer.executePausePage() == true && isAlreadyExecuted==false)
        {
            // PauseGame();

            // if(Input.GetKeyDown(KeyCode.Return))
            // {
            //     ResumeGame();
            // }
        }
            
    }

    // resume game function to set the game to resume
    public void ResumeGame()
    {
        // set the boolean value to true (resumed)
        isAlreadyExecuted = true;
        pauseMenu.SetActive(false);
        // delay when called
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        // acivate the pause menu to true (paused)
        pauseMenu.SetActive(true);
        // delay when called
        Time.timeScale = 0f;
        typer.checkpoint = 1;
    }
}
