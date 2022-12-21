using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Timers;

public class Typer : MonoBehaviour
{
    public WordBank wordBank = null;

    public Text wordOutput = null;
    public Text remaining = null;
    public Text level = null;
    public Text timer = null;
    public GameObject life1 = null;
    public GameObject life2 = null;
    public GameObject life3 = null;
    public Animator lowHealth;
    public Sprite heart = null;
    public Sprite heartless = null;
    public Text money = null;
    public SoundManager soundManager = null;
    public Shop shop = null;
    public Slider enemyHealthBar;
    public Slider playerHealthBar;
    public Slider critBar;

// CANVAS GAME OBJECT
    public GameObject SwordCover;
    public GameObject Sword;
    public GameObject SwordSwing;

    public GameObject Cave;
    public GameObject AuntumnRift;
    public GameObject Colloseum;
    public GameObject GreenMountain;
    public GameObject ShopMenu;
    public GameObject DeadPageUI;
    public List<Button> ShopButtonUI;



    private string remainingLetter = string.Empty;
    private string currentWord = string.Empty;
    private string moneyText = string.Empty;
    [HideInInspector] public int currentLevel = 0;
    
    public int checkpoint = 0;
    private int remainingWord = 1;
    private int workingWord = 0;
    private int remainingLife = 3;
    private float currentMoney = 500000f;
    public float timeRemaining = 5f;
    public float maxTime = 5f;
    //Player stat
    public float playerAttack =100f;
    private float playerCrit=0f;
    private int countCombo=0;
    //Enemy stat
    public float enemyAttack=100f;
    public float enemyAttackSpeed=3f;

    private SpriteRenderer spriteRenderer;
    public GameObject attackEffectUI;
    public GameObject getAttackEffectUI;

    public ParticleSystem blood;
    public Transform bloodPos;
    public GameObject WinPageUI;
    
    void OnEnable()//called when game object is enabled
    {
        if(Time.timeScale == 0)//check if time scale is 0
        {
            Time.timeScale = 1;//if so, set the time to 1
        }
    }

    private void Start()//called in the first frame
    {
        InvokeRepeating("EnemyAttackPlayer", enemyAttackSpeed,enemyAttackSpeed);//repeat enemy attack player based on enemy attack speed
        //LifeController();
        enemyHealthBar.maxValue=1000;//set the max value of health bar to 1000
        enemyHealthBar.value=1000;//set the max value of health bar to 1000
        playerHealthBar.maxValue=1000;//set the max value of health bar to 1000
        playerHealthBar.value=1000;//set the max value of health bar to 1000
        critBar.maxValue=20;//set the max value of crit bar to 1000
        critBar.value=0;//set the max value of crit bar to 1000

        workingWord += remainingWord;//add working word by remaining word
        InvokeRepeating("decreaseTimeRemaining", 1.0f, 1.0f);//repeat decrease time every 1 second
        SetCurrentWord();//call set current word
        SetLevel();//call set level
        SetRemainingWord(currentLevel);//call set remaining word
        // Debug.Log(currentMoney);
    }
    public void ResetTimer()//a method for reset timer
    {
        timeRemaining = maxTime;//reset time remaining to max time value
        timer.text = timeRemaining.ToString();//set the text by time remaining
    }

    private void EnemyAttackPlayer()//a method to attack player by enemy
    {
        // playerHealthBar.value-=enemyAttack;
        // if(playerHealthBar.value==0)
        // {
        //     //deadPage();
        // }
    }
    public bool CheckMoney(float price)//a method to check money
    {
        if(currentMoney >= price)//if current money is more than price, do :
        {
            currentMoney -= price;//deduct current money by price
            MoneyController();//call money controller
            return true;//if money is enough, return true
        }else{
            return false;//if not, return false
        }
    }
    public void ShowShopPage()//a method to show shop page ui
    {
        for(int i = 0; i<ShopButtonUI.Count; i++)//loop all shop button ui
        {
            ShopButtonUI[i].interactable = true;//set the interactables of those  button to true
        }
        SwordCover.SetActive(true);//set sword cover to active
        Cave.SetActive(false);//hide cave background
        Colloseum.SetActive(false);//hide colloseum background
        AuntumnRift.SetActive(false);//hide autumn rift background
        GreenMountain.SetActive(false);//hide green mountain background
        ShopMenu.SetActive(true);//show shop menu
        gameObject.SetActive(false);//hide typer game object

    }
    public void ShowWinPage()//a method to show win page menu
    {
        WinPageUI.SetActive(true);//set win page to active
    }
    
    private void decreaseTimeRemaining()//a method to decrease time remaining
    {
        timeRemaining--;//decrease time remaining by 1 point
    }

    private void SetLevel()//a method to set levels
    {
        currentLevel += 1;//add current level by one
        checkpoint += 1;//add checkpoint by one 
        if(remainingLife >= 1 && remainingLife < 3)//check if remaining life is between 1 and 3
        {
            remainingLife += 1;//add remaining life by 1
            soundManager.GetHeartSound();//call get heart sound method from sound manager script
        }
        level.text = currentLevel.ToString();//set text level by current level
    }

    private void SetRemainingWord(int level)//a method to set remaining word
    {
        if(level >= 1)//check if level is equal 1
        {
            remainingWord = level;//set remainign word by level
        }
        remaining.text = workingWord.ToString();//set remaining text by working word
    }

    private void SetCurrentWord()//a method to set current word
    {
        currentWord = wordBank.GetWord();//get word from word bank, and assign it to current word variable
        SetRemainingLetter(currentWord);//call set remainign letter method and assign current word
    }

    private void SetRemainingLetter(string newString)//a method to set remaining letter
    {
        remainingLetter = newString;//assign new string parameter to reaminign letter
        wordOutput.text = remainingLetter;//set text of word output by remaining letter
    }

    private void Update()//called every frame
    {
        timer.text = timeRemaining.ToString();//set timer text by current time remaining
        if (GameObject.Find("Game Paused").GetComponent<GamePaused>().gameIsPaused == false)//check if game paused is false
        {
            CheckInput();//if so, call check input
        }
        LifeController();//call life controller method
    }

    private void MoneyController()//a method to control money system of the game
    { 
        moneyText = currentMoney.ToString("#,##0");//make the format of money text
       
        money.text = moneyText;//set the tex of mone text UI by the moneyText variable
    }

    private void LifeController()//a method to control life system in the game
    {
        if(timeRemaining == 0f)//check if time remaining is 0f
        {
            // remainingLife--;
            // soundManager.LostHeartSound();
            playerHealthBar.value-=enemyAttack*3;//if so, deduct player health bar value by enemy attack times by 3
            playGetAttackEffect();//call play get attack effect method
            if(playerHealthBar.value <= 0f)//check if player health bar value under or equal 0
            {
                LoadDeadPage();//if so we die, so call load dead page method
            }
            SetCurrentWord();//call set current word method
            timeRemaining = maxTime;//sest the time remaining by max time
        }

        if(remainingLife < 3)//check if remaining life under 3
           
        {
            lowHealth.SetBool("Throbbing",false);//set the low health animator bool to false
            life1.GetComponent<Image>().sprite = heartless;//set sprite of life by heartless sprite
        } else//if not, then..
        {
            life1.GetComponent<Image>().sprite = heart;//set the sprite of life 1 by heart
        }

        if(remainingLife < 2)//check if remaining  life under 2
        {
            
            lowHealth.SetBool("Throbbing",true);//if so, set low health animator throbbing boolean to true
            
            life2.GetComponent<Image>().sprite = heartless;//then, set the sprite to heartless sprite
        }else
        {
            life2.GetComponent<Image>().sprite = heart;//if not, set it to heart sprite
        }

        if(remainingLife < 1)//check  if the current remaining life less than one
        {
            life3.GetComponent<Image>().sprite = heartless;//set the life3 image sprite by heartless sprite
            currentLevel -= checkpoint;//deduct current level by checkpoint
            checkpoint = 0;//set checkpoint back to zero
            SetLevel();//call set level  metohd
            SetCurrentWord();//call set current word method
            workingWord = currentLevel;//set working word by current level
            remaining.text = workingWord.ToString();//set the text of remaining text by current working word value
            remainingLife = 3;//set the remaining life to 3 again
            lowHealth.SetBool("Throbbing",false);//set low health animator throbbing boolean to false
        }else
        {
            life3.GetComponent<Image>().sprite = heart;//set the sprite of life3 image by heart sprite
            
        }
        
    }
    void LoadDeadPage()//funvtion to change the gameobject
    {
        Time.timeScale = 0;
        Cave.SetActive(false);//set gameobject cave to nonactive
        AuntumnRift.SetActive(false);//set gameobject cave to nonactive
        Colloseum.SetActive(false);//set gameobject cave to nonactive
        GreenMountain.SetActive(false);//set gameobject cave to nonactive
        DeadPageUI.SetActive(true);//set gameobject cave to nonactive
    }


    private void CheckInput()//checking input if the mouse and keyboard has been clicked
    {
        if(Input.anyKeyDown && !(Input.GetMouseButtonDown(0) //check if any input then play the sound of keyboard
            || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)))
        {
            soundManager.PlayKeyboardSound();//play the sound 
            string keysPressed = Input.inputString;//set the input string to keypressed variable

                if (keysPressed.Length == 1)//if input string is 1 then run the enterletter function
                EnterLetter(keysPressed);//run the enterletter function by matching the word we type
        }
    }


    private void EnterLetter(string typedLetter)//function to match the word we type
    {
        
        if(IsCorrectLetter(typedLetter))//if the word we type is correct then will run the function below
        {
            //decrease EnemyHealthBar
            // enemyHealthBar.value-=playerAttack;
            countCombo++;//count combo value for add combo vlue
            
            if(countCombo==20)//set if combo value is 20 then run the function inside
            {
                enemyHealthBar.value-=playerAttack*2;//decrese enemy health by doouble player attack
                countCombo=0;// set the count combo to zwero again
            }


            RemoveLetter();//run the remove letter function
            //Debug.Log(typedLetter);

            if (IsWordComplete())//if the word we type completely true then run the function inside
            {                 
                enemyHealthBar.value-=playerAttack;//decrese enemy health by player attack value
                SwingSword();//run the function swing sword
                currentMoney += 1000;//add the money 1000
                MoneyController();//run the moneycontroller function
                if(enemyHealthBar.value<=0)// if the enemy die (health is less than 0)check if 
                {
                    if(Level.level4 == true)//check if current level is level 4
                    {
                        ShowWinPage();//call show win page method // showing the level page
                    }else
                    {
                        ShowShopPage();//call show shop page method // showing the shop page
                    }
                }
                timeRemaining = maxTime;//set the time remaining back to its max time value
                ReduceWorkingWord();//call reduce working word method
                
                if (workingWord == 0)//check  if working word is 0 
                {
                    SetLevel();//call set level method
                    SetRemainingWord(currentLevel);//call set remaining word method and assign current level
                    workingWord += remainingWord;//add working word by remaining  word
                    // timeRemaining = 60f;
                }
                remaining.text = workingWord.ToString();//set the remaining text by current working word
                SetCurrentWord();//call set current word method
                
            }
                
        }
        else
        {
            countCombo=0;//set count combo variable back to 0
            playGetAttackEffect(); //activate the played get attacked effect
            playerHealthBar.value-=enemyAttack;//decrease player health bar by enemy attack value
            if(playerHealthBar.value <= 0f) // check if the player health is less than 0
            {
                LoadDeadPage(); // player is dead, calling the function and navigate to dead page
            }
        
        }
        critBar.value=countCombo;//set the critbar value by count combo value

    }
    void playGetAttackEffect()//a method to play attacked effect
    {
        SoundManager.playGruntSound();//play the grunt sound
        getAttackEffectUI.SetActive(true);//set active the ui attack effect
        Invoke("deactivateGetAttackEffect", 0.3f);//deactivate tffeer .3f second
    }
    void deactivateGetAttackEffect()//a method to deactivate get attack effect
    {
        getAttackEffectUI.SetActive(false);//show the get attack effect u
    }
    void SwingSword()//metwing the sword ui object
    {
        blood.Play();//play the blood particle object
        SoundManager.playSwingSound();//play the swing sound
        attackEffectUI.SetActive(true);//activate the ui attack effect
        Sword.SetActive(false);//hide the idle sword image
        SwordSwing.SetActive(true);//show the swing sword image
        Invoke("IdleSword",0.3f);//call idle sword method in 0.3f
    }
    void IdleSword()// a method to set the sword to idle
    {
        attackEffectUI.SetActive(false);//hide the attack effect ui
        Sword.SetActive(true);//show the idle sword image
        SwordSwing.SetActive(false);//hide the swing sword image
    }

    private bool IsCorrectLetter(string letter)//a method to check if the typed letter is correct
    {
        return remainingLetter.IndexOf(letter) == 0;//if 0 return false else true
    }

    private void RemoveLetter()//Removing typed in letters
    {
        string newString = remainingLetter.Remove(0,1);//remove the typed word by the player
        SetRemainingLetter(newString);//call set remaining letter method to update the remaining  letter
    }

    public bool IsWordComplete()//Checking the typing completion of a word
    {
        return remainingLetter.Length == 0;//if the length is 0, mark the word complete as true
    }

    private void ReduceWorkingWord()//a method to reduce the working word
    {
        workingWord -= 1;//reduce the working word by 1
    }
    public bool executePausePage()//a method to show pause page
    {
        if (currentLevel == 1)//check if the current level is 1
        {
            return false;//if so, do not show pause page
        }
        else if((currentLevel - 1) % 5 == 0 )//check if the current level is multiply of 5
        {
            return true;//if so, show pause page
        }
        return false;//if none of them true, do not show pause page
    }

   public bool checkMoney(float price) // checking money value
   {
       if(currentMoney >= price)//if current money is more than the  price
       {
           return true;//mark it as true
       } else
       {
           return false;//if not, mark it as false
       }
   }
}
