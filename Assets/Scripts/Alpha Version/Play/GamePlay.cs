using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject gameOverMenu;
    public GameObject winnerMenu;

    public string nextScene;

    public void Update()
    {   
        if (player.GetComponent<FighterControllerBase>().GetHealthPoints() <= 0)
        {
            GameOver();
        }

        if(enemy != null)
            if(enemy.GetComponent<FighterControllerBase>().GetHealthPoints() <= 0){
                Victory();
            }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Victory()
    {
        Destroy(enemy);
        winnerMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
