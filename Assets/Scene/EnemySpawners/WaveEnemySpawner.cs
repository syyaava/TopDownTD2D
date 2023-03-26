using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WaveEnemySpawner : EnemySpawnerBase //Изменить спавн так чтобы противники появлялись за экраном
{
    public int PathNumber = 0;
    public List<EnemyWave> Waves = new List<EnemyWave>();
    public override bool IsDone => Waves.All(x => x.IsDone && x.SpawnedEnemies.Count == 0);
    
    private void Awake()
    {
        EnemyCount = Waves.Sum(x => x.EnemyCountInWave);
    }

    public override IEnumerator Spawn()
    {
        EnemySpawnPoint = SceneController.Instance.Paths[PathNumber].Waypoints[0];
        foreach(var wave in Waves)        
        {            
            yield return new WaitForSeconds(wave.waveDelaySecs);
            StartCoroutine(wave.Spawn(EnemySpawnPoint.position, transform, PathNumber));
        }
    }
}
