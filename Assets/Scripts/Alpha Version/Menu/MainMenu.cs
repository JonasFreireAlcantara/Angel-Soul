using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }*/
    public void PlayGame(string cena)
    {
        SceneManager.LoadScene(cena);
        FindObjectOfType<AudioManager>().StopIntro("Intro_intro");
        FindObjectOfType<AudioManager>().StopLoop("Intro_loop");
        /*FindObjectOfType<AudioManager>().IntroPlay("Mammon_intro");
        FindObjectOfType<AudioManager>().LoopPlay("Mammon_loop");*/
    }


    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
