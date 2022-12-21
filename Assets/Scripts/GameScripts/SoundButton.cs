using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : MonoBehaviour
{
    public Sprite OffSprite;
    public Sprite OnSprite;
    public Button Button;

    public bool soundIsOn = true;   // Default state
    
    public void ChangeImage(){      // Switch between on and off sprite for the sound button
     if (Button.image.sprite == OnSprite)//check if the on sprite is active
         Button.image.sprite = OffSprite;//if so, set it to off sprite
     else {
         Button.image.sprite = OnSprite;//else set the on sprite to active
     }
 }
}
