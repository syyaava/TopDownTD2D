using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public GameObject GameOverMenu;
    private void Start()
    {
        GameOverMenu.SetActive(false);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }
}
