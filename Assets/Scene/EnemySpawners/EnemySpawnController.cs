using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour //TODO: Баг с моментальным геймовером
{
    private EnemySpawnerBase[] spawners;
    public long TotalEnemyCount = 0;
    public bool IsEndOfGame => spawners.All(x => x.IsDone);

    private void Start()
    {
        spawners = GetComponentsInChildren<EnemySpawnerBase>();
        TotalEnemyCount = spawners.Sum(x => x.EnemyCount);        
        if (spawners == null || spawners.Length == 0)
            return;
        
        foreach (var spawner in spawners)
        {
            StartCoroutine(spawner.Spawn());
        }        
    }
}
