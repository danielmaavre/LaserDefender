using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timebetweenWaves = 0f;
    WaveConfigSO currentWave;    

    void Start()
    {
       StartCoroutine(SpawnEnemyWaves());        
    }

    public WaveConfigSO GetCurrentWave(){
        return currentWave;
    }    

    IEnumerator SpawnEnemyWaves()
    {        
        foreach (WaveConfigSO wave in waveConfigs)
        {
            for (int i = 0; i < wave.GetEnemyCount(); i++)
            {
                Instantiate(
                    wave.GetEnemyPrefab(i),
                    wave.GetStartingWaypoint().position,
                    Quaternion.identity,
                    transform);  
                yield return new WaitForSeconds(wave.GetRandomSpawnTime());                      
            } 

            yield return new WaitForSeconds(timebetweenWaves);                     
        }
    }



}
