using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public static PatrolPath Path;

    private void Awake()
    {
        if(Path == null)
            Path = GetComponentInChildren<PatrolPath>();
    }
}
