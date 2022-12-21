using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoBackground : MonoBehaviour
{
   public string url;
   public VideoPlayer vidplayer;

   // Start is called before the first frame update
   void Start()
   {
       vidplayer = GetComponent<VideoPlayer>();//assign vidplayer method by video player component  of this game object
       vidplayer.url = url;//set the url of the url field assigned from the inspector
   }

   // Update is called once per frame
   void Update()
   {
       if (Input.anyKey)//check if there are any input by the user
       {
           Play();//call play method
       }

   }

   void Play()//a method to play the video  player
   {
       vidplayer.Play();//play the video
       vidplayer.isLooping = true;//set the looping property to true
   }
}