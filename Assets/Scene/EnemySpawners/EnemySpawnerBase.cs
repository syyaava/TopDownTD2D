using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawnerBase : MonoBehaviour
{
    public Transform EnemySpawnPoint;
    public int EnemyCount = 0;
    public abstract bool IsDone { get; }
    public abstract IEnumerator Spawn();
}
