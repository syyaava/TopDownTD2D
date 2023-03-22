using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawnerBase : MonoBehaviour
{
    public Transform EnemySpawnPoint;
    public int EnemyCount = 0;
    public abstract IEnumerator Spawn();
    public abstract void AddSpawnedEnemyCount(int count = 1);
}
