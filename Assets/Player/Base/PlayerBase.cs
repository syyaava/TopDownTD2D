using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    public static string PlayerBaseTag = "Player";
    
    private void Start()
    {        
        tag = PlayerBaseTag;
    }

    public void GameOver()
    {        
        GamePauseController.IsGameOver = true;
    }
}
