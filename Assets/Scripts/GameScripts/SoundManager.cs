using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource keyboardSound1;
    public AudioSource keyboardSound2;
    public AudioSource keyboardSound3;
    public AudioSource keyboardSound4;
    public AudioSource keyboardSound5;
    public AudioSource keyboardSound6;
    public AudioSource keyboardSound7;
    public AudioSource throbbingSound;
    public AudioSource mouseClicked;
    public AudioSource mouseReleased;
    public AudioSource lostHeartSFX;
    public AudioSource getHeartSFX;
    public AudioSource illegalSound;
    public AudioSource swingSwordSound;
    public AudioSource gruntSound;
    public AudioSource activatePotionSound;
    public AudioSource buyPotionSound;
    private List<AudioSource> audios = new List<AudioSource>();
    private AudioSource playedKeyboardSound;
    static SoundManager sm;
    private void Start()//called in the first frame
    {
        sm = this;//set the sound manager static variable by this class
        audios.AddRange(new List<AudioSource>()  {keyboardSound1,keyboardSound2,keyboardSound3,keyboardSound4,keyboardSound5,keyboardSound6,keyboardSound7});//add keyboard sounds
    }
    private void Update()//called every frame
    {
        setKeyboardSound();//call set keyboard sound method
        MouseSoundController();//call mouse sound controller method
    }
    public static void playSwingSound()//a method to play swing sound
    {
        sm.swingSwordSound.Play();//play the swing sound 
    }
    public static void playGruntSound()//a method to play grunt sound
    {
        sm.gruntSound.Play();//play the grunt sound
    }
    public static void playPotionSound()//a method to play potion sound
    {
        sm.activatePotionSound.Play();//play the sound
    }
    public static void playBuyPotionSound()// a method to play buy potion sound effect
    {
        sm.buyPotionSound.Play();//play the buy sound
    }

    public void LostHeartSound()//a method to play lost heart sound
    {
        lostHeartSFX.Play();//play the sound
    }
    public void GetHeartSound()//a method to play get heart sound
    {
        getHeartSFX.Play();//play the sound
    }

    public void IllegalSound()//a method to play illegal sound
    {
        illegalSound.Play();//play the sound
    }

    public void MouseSoundController()//a method to control mouse sound
    {
        if( Input.GetMouseButtonDown(0))//check  if there is left click input by the user
        {
            mouseClicked.Play();//play mouse click sound
        }
        if(Input.GetMouseButtonUp(0))//check  if left click is released by the user
        {
            mouseReleased.Play();//play mouse released sound
        }
    }

    private void setKeyboardSound()//a method set the keyboard sounds efffects
    {
        playedKeyboardSound = audios[Random.Range(0,audios.Count)];//get the keyboard sound
    }
   
    public void PlayKeyboardSound()//a method to play the keyboard sound
    {
        playedKeyboardSound.Play();//play the keyboard sound
    }

    public void PlayThrobbingSound()// a method to play throbbing sound
    {
        throbbingSound.Play();//play the sound
    }
}
