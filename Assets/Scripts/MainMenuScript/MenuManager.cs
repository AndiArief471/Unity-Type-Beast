using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Sounds
    [SerializeField] private AudioSource playButtonSound;
    public Animator Anim;
    public Image Img;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Game");
        playButtonSound.Play();
        //StartCoroutine(Fade("Game","FadeOut","FadeIn"));
    }
    public void MenuButton()
    {
        SceneManager.LoadScene("MainMenu");
        playButtonSound.Play();
        //StartCoroutine(Fade("MainMenu","FadeIn","FadeOut"));
    }

    IEnumerator Fade(string name, string param1, string param2)
    {
        Anim.SetBool(param1, true);
        Anim.SetBool(param2, false);
        // yield return new WaitUntil(()=>Img.color.a==1);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(name);
    }
}
