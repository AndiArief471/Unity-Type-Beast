using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelButton : MonoBehaviour
{
    public GameObject colloseum;
    public GameObject AuntumnRift;
    public GameObject GreenMountain;
    public GameObject shopMenu;
    public int currentLevel=0;    //First stage
    public Level levelScript;
    

    public void addLevel()
    {
        shopMenu.SetActive(false);//hide the shop menu
        currentLevel+=1;//add current level by 1 
        if(currentLevel==1)//check if current level is equal to 1
        {
            colloseum.SetActive(true);  // Second stage
            levelScript.Level2();   // Call the function in Level.cs Script
        }
        else if(currentLevel==2)//check if current level is equal to 2
        {
          AuntumnRift.SetActive(true);  // Third stage
          levelScript.Level3();   // Call the function in Level.cs Script
        }  
        else if(currentLevel==3)//check if current level is equal to 3
        {
          GreenMountain.SetActive(true);  // Fourth stage
          levelScript.Level4();   // Call the function in Level.cs Script
        }   
    }

}
