using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnerMenu : MonoBehaviour
{
    public void Next(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
