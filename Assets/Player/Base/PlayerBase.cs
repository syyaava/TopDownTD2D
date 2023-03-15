using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public static string PlayerBaseTag = "Player";
    public GameObject GameOverMenu;
    private void Start()
    {
        GameOverMenu.SetActive(false);
        tag = PlayerBaseTag;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
        GamePauseController.IsGameOver = true;
    }
}
