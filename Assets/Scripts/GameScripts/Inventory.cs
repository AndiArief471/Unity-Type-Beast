using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    public Image image;
    public TextMeshProUGUI text;
    public string PotionName;
    public float percentage;
    public float price;

    public Typer typer;     //

    public Sprite emptyImage;
    public Animator attAnim;
    public Animator defAnim;
    public Animator timeAnim;
    public Animator healthAnim;
    public Animator bombAnim;
    
    public void UsePotion()
    {
        //check if the sprite is empty
        if(image.sprite == emptyImage) return;//if sprite is empty, return nothing
        //playing the play potion sound from sound manager
        SoundManager.playPotionSound();
        switch (PotionName)
        {
            case "Defense Potion":
                //activate the defense function
                defense();
                break;
            case "Attack Potion":
                //activate the attack function
                attack();
                break;
            case "Add Time":
                //activate the addTime function
                addTime();
                break;
            case "Health Potion":
                //activate the health function
                health();
                break;
            case "Boom":
                //activate the bomb function
                bomb();
                break;
        }
    }
    void defense()
    {
        // Debug.Log("called" + PotionName);
        //set the defense animation boolean to true
        defAnim.SetBool("isActive", true);//turn animation on
        //take the enemy attack method to change the value
        typer.enemyAttack-=percentage;//decerease the enemy attack value to the percentage of defense potion
        PotionName="";//let the string potion name be filled later
        image.sprite=emptyImage;//turn the image into empty if the bomb image has been clicked
        Invoke("cancelDefense", 30f);
    }
    void attack()
    {
        // Debug.Log("called" + PotionName);
        //set the attack animation boolean to true
        attAnim.SetBool("isActive", true);//turn animation on
        //take the player attack method to change the value
        typer.playerAttack+=percentage;//set the attack playervalue to the percentage of percentage potion
        PotionName="";//let the string potion name be filled later
        image.sprite=emptyImage;//turn the image into empty if the bomb image has been clicked
        Invoke("cancelAttack", 30f);//call the cancel attack function after 30seconds
    }
    void addTime()
    {
        timeAnim.SetBool("isActive", true);//turn animation on
        typer.maxTime+=percentage;
        typer.timeRemaining = percentage;//set the time remaining into the percentage of potion add time
        PotionName="";//let the string potion name be filled later
        image.sprite=emptyImage;//turn the image into empty if the bomb image has been clicked
        Invoke("cancelTime", 30f);//call the cancel canceltime function after 30seconds
    }
    void health()
    {
        healthAnim.SetBool("isActive", true);//turn animation on
        typer.playerHealthBar.value+=percentage;//increase healht player
        PotionName="";//let the string potion name be filled later
        image.sprite=emptyImage;//turn the image into empty if the bomb image has been clicked
        Invoke("cancelHealth", 3f);//call the cancel cancelhealth after 3seconds
    }
    void bomb()//function bomb to hit enemy by big attack
    {
        bombAnim.SetBool("isActive", true);//turn animation on
        typer.enemyHealthBar.value-=percentage;//decrease enemy health bar by bomb percentage
        PotionName="";//let the string potion name be filled later
        image.sprite=emptyImage;//turn the image into empty if the bomb image has been clicked
        Invoke("cancelBomb", 1f);//call the cancel bomb after 3seconds
    }
    void cancelDefense()//function to cancel the defense f
    {
        defAnim.SetBool("isActive", false);//stop the animation
        typer.enemyAttack+=percentage;//add enemy attack to normal 
    }
    void cancelAttack()//function to cancel the add attack function 
    {
        attAnim.SetBool("isActive", false);//stop the animation
        typer.playerAttack-=percentage; //decrease percentage to normal again
    }
    void cancelTime() //function to cancel the addtime function 
    {
        timeAnim.SetBool("isActive", false);//stop the animation
        typer.maxTime-=percentage;//decrease the max time
    }
    void cancelHealth()//function to cancel the addhealth function 
    {
       healthAnim.SetBool("isActive", false); //stop the animation
    }
    void cancelBomb()//function to cancel the bomb function 
    {
       bombAnim.SetBool("isActive", false); //stop the animation
    }


}
