using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]
public class WaveConfigSO : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform pathPrefab;
    [SerializeField] float moveSpeed = 5f;

    public float getMoveSpeed(){
        return moveSpeed;
    }

    public Transform GetStartingWaypoint(){
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints(){
        List<Transform> waypoints = new List<Transform>();
        foreach (Transform child in pathPrefab)
        {
            waypoints.Add(child);
        }

        return waypoints;
    }

    public int GetEnemyCount(){
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefab(int idx){
        return enemyPrefabs[idx];
    }
}
