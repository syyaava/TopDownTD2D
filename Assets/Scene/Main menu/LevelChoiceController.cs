using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChoiceController : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public void GoToMainMenu()
    {
        MainMenuPanel.SetActive(true);
        gameObject.SetActive(false);
    }
}
