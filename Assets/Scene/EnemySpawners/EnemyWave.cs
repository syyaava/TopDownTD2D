using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "NewEnemyWave", menuName = "Data/EnemyWave")]
public class EnemyWave : ScriptableObject //TODO: Добавить возможность выбора противника по весу (С начала игры вес равен минимальному значению так, что
    //появляются только слабые противники, но со временем вес увеличивается.
    //Также можно сделать так, чтобы у волны был вес и туда пихало противников +-15% равных по весу в сумме.
{
    public float waveDelaySecs = 90f;
    public int EnemyCountInWave = 3;
    [SerializeField]
    private float delayBetweenEnemies = 1.0f;
    public List<GameObject> EnemyPrefabs = new List<GameObject>();
    public bool IsDone = false;
    [HideInInspector]
    public List<GameObject> SpawnedEnemies = new List<GameObject>();

    public IEnumerator Spawn(Vector3 position, Transform parent, int pathNumber)
    {
        for (var i = 0; i < EnemyCountInWave; i++)
        {
            var enemy = Instantiate(SelectEnemy(EnemyPrefabs), position, Quaternion.identity, parent);
            SetPathNumberToSpawnedEnemy(pathNumber, enemy);

            SetWaveLinkToSpawnedEnemy(enemy);
            SpawnedEnemies.Add(enemy);

            yield return new WaitForSeconds(delayBetweenEnemies);
        }
        IsDone = true;
    }

    private void SetWaveLinkToSpawnedEnemy(GameObject enemy)
    {
        var enemyController = enemy.GetComponent<EnemyController>();
        if (enemyController != null)
            enemyController.ParentWave = this;
    }

    private static void SetPathNumberToSpawnedEnemy(int pathNumber, GameObject enemy)
    {
        var movingComponent = enemy.GetComponent<AIWaypointMoving>();
        if (movingComponent != null)
            movingComponent.PathNumber = pathNumber;
    }

    private GameObject SelectEnemy(IEnumerable<GameObject> enemyPrefabs)
    {
        return enemyPrefabs.ElementAt(0);
    }

    public override string ToString()
    {
        return $"Enemy count: {EnemyCountInWave}. Delay between enemies: {delayBetweenEnemies}. Enemies: {string.Join(";", EnemyPrefabs)}";
    }

    public void DeleteObjectFromSpawnedList(GameObject obj)
    {
        SpawnedEnemies.Remove(obj);
    }
}
