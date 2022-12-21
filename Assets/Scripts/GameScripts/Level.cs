using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public Typer typerScript;
    public static bool level4 = false;

    public void Level2()    // Stage 2 Enemy Stats
    {
        level4 = false;
        // set the max value of enemy health bar to 2000
        typerScript.enemyHealthBar.maxValue=2000;
        typerScript.enemyHealthBar.value=2000;//set the enemy health bar value to 2000
        typerScript.playerHealthBar.maxValue=1000;//set the player health bar value to 2000
        // typerScript.playerHealthBar.value=1000;
        // take the reset timer method from typerscript to reset the timer when the level is changed to next level
        typerScript.ResetTimer();
        // set the critical bar value to 0 each time the level is changed
        typerScript.critBar.value=0;
    }
    public void Level3()    // Stage 3 Enemy Stats
    {
        level4 = false;
        // set the max value of enemy health bar to 4000
        typerScript.enemyHealthBar.maxValue=4000;
        typerScript.enemyHealthBar.value=4000;//set the enemy health bar value to 4000
        typerScript.playerHealthBar.maxValue=1000;
        // typerScript.playerHealthBar.value=1000;
        // take the reset timer method from typerscript to reset the timer when the level is changed to next level
        typerScript.ResetTimer();
        // set the critical bar value to 0 each time the level is changed
        typerScript.critBar.value=0;
    }
    public void Level4()    // Stage 4 Enemy Stats
    {
        level4 = true;
        // set the max value of enemy health bar to 8000
        typerScript.enemyHealthBar.maxValue=8000;
        typerScript.enemyHealthBar.value=8000;
        typerScript.playerHealthBar.maxValue=1000;
        // typerScript.playerHealthBar.value=1000;
         // take the reset timer method from typerscript to reset the timer when the level is changed to next level
        typerScript.ResetTimer();
        typerScript.critBar.value=0;// set the critical bar value to 0 each time the level is changed
    }
}
