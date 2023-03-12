using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemySpawner : EnemySpawnerBase //Изменить спавн так чтобы противники появлялись за экраном
{    
    public List<EnemyWave> Waves = new List<EnemyWave>();

    public override IEnumerator Spawn()
    {
        EnemySpawnPoint = SceneController.Path.Waypoints[0];
        foreach(var wave in Waves)
        {
            yield return new WaitForSeconds(wave.waveDelaySecs);
            PGFLogger.Log($"Start wave {wave.name}. {wave}");
            StartCoroutine(wave.Spawn(EnemySpawnPoint.position, transform));
        }
    }
}
