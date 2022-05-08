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
    }


    public void QuitGame()
    {
        //Debug.Log("Quit");
        Application.Quit();
    }
}
