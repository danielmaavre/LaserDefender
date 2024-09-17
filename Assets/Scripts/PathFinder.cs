using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIdx = 0;

    private void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWayPoints();
        transform.position = waypoints[waypointIdx].position;        
    }

    void Update()
    {
        FollowPath();
        
    }

    private void FollowPath()
    {
        if(waypointIdx < waypoints.Count){
            Vector3 targetPosition = waypoints[waypointIdx].position;
            float delta = waveConfig.getMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position,targetPosition, delta);

            if(transform.position == targetPosition){
                waypointIdx++;
            }
        } else{
            Destroy(gameObject);
        }
    }
}
