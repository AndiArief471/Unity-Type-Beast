using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoScript : MonoBehaviour
{
    public void Show()//to show the game object
    {
        gameObject.SetActive(true);
    }

    public void Hide()//hide gameobject by turn the active to false
    {
        gameObject.SetActive(false);
    }
}
