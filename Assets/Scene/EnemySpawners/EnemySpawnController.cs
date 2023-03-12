using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    private EnemySpawnerBase[] spawners;

    private void Start()
    {
        spawners = GetComponentsInChildren<EnemySpawnerBase>();
        if (spawners == null || spawners.Length == 0)
            return;

        foreach (var spawner in spawners)
        {
            StartCoroutine(spawner.Spawn());
        }
    }
}
