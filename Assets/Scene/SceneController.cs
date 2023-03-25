using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static List<PatrolPath> Paths;

    private void Awake()
    {
        if(Paths == null)
            Paths = GetComponentsInChildren<PatrolPath>().ToList();
        Time.timeScale = 1.0f;
    }
}
