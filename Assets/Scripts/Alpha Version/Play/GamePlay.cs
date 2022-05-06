using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public PlayerController player;
    public GameObject gameOverMenu;

    public void Update()
    {
        if (player.life <= 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0f;
    }
}
