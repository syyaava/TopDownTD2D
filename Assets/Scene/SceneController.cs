using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance;
    public List<PatrolPath> Paths;

    private void Awake()
    {
        Instance = this;
        if (Paths == null || Paths.Count == 0)
            Paths = GetComponentsInChildren<PatrolPath>().ToList();
        Time.timeScale = 1.0f;
    }
}
