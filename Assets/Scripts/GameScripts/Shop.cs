using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Shop : MonoBehaviour
{   //set all the variable to fhte shop class
    public Typer typerScript;
    public List<GameObject> Potions;
    public Image SpotImage;
    public TextMeshProUGUI SpotPrice;
    public TextMeshProUGUI SpotDesc;
    public GameObject InsufficientMoney;
    
    private string PotionName;
    private float percentage;
    private float price;

    public List<Inventory> inventoryList;
    

    void OnEnable()     // Called if shop is set to active
    {
        ShowPotion();//run the showpotion function
    }
    public int EmptySlot()//function emptyslot
    {   
        //looping through each item in inventory list
        for(int i =0;i<inventoryList.Count; i++)
        {
            if(inventoryList[i].PotionName=="")
            {
                //returning each of the potion name
                return i;
            }
        }
        return -1;//return the last indext
    }
    
    public void Buy()//function to buy
    {
        int emptySlot=EmptySlot();
        //Debug.Log(emptySlot);
        if(emptySlot==-1) return;
        //money validation
        bool moneyIsEnough = typerScript.CheckMoney(price);//check if money is enough to buy
        if(!moneyIsEnough) // if money is not enough
        {
            InsufficientMoney.SetActive(true); // set boolean value to true (no money)
            return;
        }
        inventoryList[emptySlot].image.sprite=SpotImage.sprite;//set the image sprite into the potion image in shop
        inventoryList[emptySlot].PotionName=PotionName;
        inventoryList[emptySlot].percentage=percentage;
        inventoryList[emptySlot].price=price;
        SoundManager.playBuyPotionSound(); // playing the music from sound manager
    }
    public void ShowPotion()
    {
        //showing the random potion to the shop each time the show potion function is called
        int i=UnityEngine.Random.Range(0,Potions.Count);
        // getting the potion component
        Potion potionScript = Potions[i].GetComponent<Potion>();
        potionScript.ManageInfo();
        // Get the data of each potion prefabs
        SpotImage.sprite=potionScript.image;    // Sprite
        SpotDesc.text=potionScript.description;     // Description
        PotionName=potionScript.name;      // Potion Name
        percentage=potionScript.percentage;     // Percentage value
        price=potionScript.price;     // Price
        SpotPrice.text=price.ToString();

    }
}
