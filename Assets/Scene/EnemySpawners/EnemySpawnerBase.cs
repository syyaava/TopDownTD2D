using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemySpawnerBase : MonoBehaviour
{
    public Transform EnemySpawnPoint;
    public abstract IEnumerator Spawn();
}
