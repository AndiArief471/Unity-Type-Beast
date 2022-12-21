using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManagerPerCanvas : MonoBehaviour
{
    //set all variable for gameobject and audio
    public AudioSource caveAudio;
    public AudioSource colloseumAudio;
    public AudioSource GMountainAudio;
    public AudioSource ARTAudio;
    public GameObject cave;
    public GameObject colloseum;
    public GameObject GMountain;
    public GameObject ART;

    

    void Update()//update function 
    {   //if only cave who active in hierarchy then call the function inside
        if(cave.activeInHierarchy == true && colloseum.activeInHierarchy == false && GMountain.activeInHierarchy == false && ART.activeInHierarchy == false)
        {
            if(caveAudio.isPlaying==false)//if the audio is not playing then run the function inside
            {
                caveAudio.Play();//play cave audio
                colloseumAudio.Stop();//stop the aduio
                ARTAudio.Stop();//stop the aduio
                GMountainAudio.Stop();//stop the aduio
            }
            
        }//if only colloseum who active in hierarchy then call the function inside
        if(cave.activeInHierarchy == false && colloseum.activeInHierarchy == true && GMountain.activeInHierarchy == false && ART.activeInHierarchy == false)
        {
            
            if(colloseumAudio.isPlaying==false)//if the audio is not playing then run the function inside
            {
                caveAudio.Stop();//stop the aduio
                ARTAudio.Stop();//stop the aduio
                GMountainAudio.Stop();//stop the aduio
                colloseumAudio.Play();//play cave audio
            }
            
        }//if only gmountain who active in hierarchy then call the function inside
        if(cave.activeInHierarchy == false && colloseum.activeInHierarchy == false && GMountain.activeInHierarchy == true && ART.activeInHierarchy == false)
        {
            if(GMountainAudio.isPlaying==false)//if the audio is not playing then run the function inside
            {
                caveAudio.Stop();//stop the aduio
                ARTAudio.Stop();//stop the aduio
                colloseumAudio.Stop();//stop the aduio
                GMountainAudio.Play();//play cave audio
            }
            
        }//if only art who active in hierarchy then call the function inside
        if(cave.activeInHierarchy == false && colloseum.activeInHierarchy == false && GMountain.activeInHierarchy == false && ART.activeInHierarchy == true)
        {
            if(ARTAudio.isPlaying==false)//if the audio is not playing then run the function inside
            {
                caveAudio.Stop();//stop the aduio
                ARTAudio.Play();//play cave audio
                colloseumAudio.Stop();//stop the aduio
                GMountainAudio.Stop();//stop the aduio
            }
            
        }
    }

    public void MuteSound()//mute thee audio function
    {
        caveAudio.mute = !caveAudio.mute;//set the cave audio mute
        ARTAudio.mute = !ARTAudio.mute;//set the cave audio mute
        colloseumAudio.mute = !colloseumAudio.mute;//set the cave audio mute
        GMountainAudio.mute = !GMountainAudio.mute;//set the cave audio mute
    }
}
