using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveEnemySpawner : EnemySpawnerBase //Изменить спавн так чтобы противники появлялись за экраном
{   
    public List<EnemyWave> Waves = new List<EnemyWave>();
    
    private void Awake()
    {
        EnemyCount = Waves.Sum(x => x.EnemyCountInWave);
    }

    public override IEnumerator Spawn()
    {
        EnemySpawnPoint = SceneController.Path.Waypoints[0];
        foreach(var wave in Waves)
        {
            yield return new WaitForSeconds(wave.waveDelaySecs);
            StartCoroutine(wave.Spawn(EnemySpawnPoint.position, transform, this));
        }
    }

    public override void AddSpawnedEnemyCount(int count = 1)
    {
        EnemyCount += count;
    }
}
