using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePaused : MonoBehaviour
{
    public GameObject pauseMenu;

    public bool gameIsPaused = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // take input from user (if the user press escape button)
        {
            PauseGame(); // call pause game function to pause the game
        }
    }

    public void PauseGame()
    {       // Ref : https://claudiograssi.medium.com/unity3d-basics-getcomponent-and-script-communication-22df1367e1b8
        if(gameIsPaused)
        {
            Time.timeScale = 1f; // delay 1f
            gameIsPaused = false; // setting the boolean to false
            GameObject.Find("SoundManagerPerCanvas").GetComponent<AudioSource>().volume = 1f; // calling a music
            Debug.Log("game is not paused");
            Debug.Log("curGamePaused = 1");  
            pauseMenu.SetActive(false); // activate the pause menu
        }
        else 
        {
            Time.timeScale = 0f;
            gameIsPaused = true;
            GameObject.Find("SoundManagerPerCanvas").GetComponent<AudioSource>().volume = 0.3f; // calling a music
            Debug.Log("game is paused");
            Debug.Log("curGamePaused = 0");            
            pauseMenu.SetActive(true); // activate the pause menu
        }
    }
}
