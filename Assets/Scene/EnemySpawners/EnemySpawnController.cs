using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour //TODO: ��� � ������������ ����������
{
    private EnemySpawnerBase[] spawners;
    public long TotalEnemyCount = 0;

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
