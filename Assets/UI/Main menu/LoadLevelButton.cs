using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelButton : MonoBehaviour
{
    public string LevelName = "_name_";

    public void LoadLevel()
    {
        SceneManager.LoadScene(LevelName, LoadSceneMode.Single);
    }
}
