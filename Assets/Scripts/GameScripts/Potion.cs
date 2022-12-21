using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [HideInInspector] public float percentage;
    public string name;
    [HideInInspector] public string description;
    [HideInInspector] public float price;
    
    public Sprite image;
    public void ManageInfo()
    {
        if(name == "Defense Potion" || name == "Attack Potion")    //Get the name of prefabs in the field
        {
            // set random value from 1 to 6 to be the multiplier for the percentage of the potion
            int rand = UnityEngine.Random.Range(1,6);
            percentage = (rand*10);
            price = rand * 20000;    // Increase price of the item based on the rand variable
            description = "+" + (int)(percentage) + "% " + name;    // Renaming the descriptioon field to the new one
        }
        else if(name == "Health Potion")    //Get the name of prefabs in the field
        {
            // set random value between 1 to 6 to get the percentage of the health potion
            int rand = UnityEngine.Random.Range(1,6);
            percentage = (rand*100);
            price = rand * 20000;    // Increase price of the item based on the rand variable
            description = "+" + (int)(percentage) + " " + name;     // Renaming the descriptioon field to the new one
        }
        else if(name == "Add Time")     //Get the name of prefabs in the field
        {
            //set random value between 1 to 6 to get the amount of seconds for the add time potion
            int rand = UnityEngine.Random.Range(1,6);   
            percentage = rand;
            price = rand * 20000;    // Increase price of the item based on the rand variable
            description = "+" + (int)(percentage) + " sec " + name;     // Renaming the descriptioon field to the new one
        }
        else if(name == "Boom")     //Get the name of prefabs in the field
        {
            // set random value between 1 to 6 to get the amount of damage for the boom potion
            int rand = UnityEngine.Random.Range(1,6);
            percentage = (rand*500);
            price = rand * 20000;    // Increase price of the item based on the rand variable
            description = (int)(percentage) + " instant damage";     // Renaming the descriptioon field to the new one
        }
    }
}
