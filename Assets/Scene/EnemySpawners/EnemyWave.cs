﻿using System;
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
    [SerializeField]
    private int enemyCountInWave = 3;
    [SerializeField]
    private float delayBetweenEnemies = 1.0f;
    public List<GameObject> EnemyPrefabs = new List<GameObject>();

    public IEnumerator Spawn(Vector3 position, Transform parent)
    {
        for (var i = 0; i < enemyCountInWave; i++)
        {
            Instantiate(SelectEnemy(EnemyPrefabs), position, Quaternion.identity, parent);
            yield return new WaitForSeconds(delayBetweenEnemies);
        }
    }

    private GameObject SelectEnemy(IEnumerable<GameObject> enemyPrefabs)
    {
        return enemyPrefabs.ElementAt(0);
    }

    public override string ToString()
    {
        return $"Enemy count: {enemyCountInWave}. Delay between enemies: {delayBetweenEnemies}. Enemies: {string.Join(";", EnemyPrefabs)}";
    }
}
