using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] GameObject pathPrefab;
    [SerializeField] float timeBetweenSpawns = 1f;
    [SerializeField] float spawnRandomFactor = 0.5f;
    [SerializeField] int numberOfEnemies = 5;
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float MinSpawnTime = 0.2f;

    public GameObject GetEnemyPrefab(int index)
    {
        return enemyPrefabs[index];
    }

    public GameObject GetRandomEnemy()
    {
        int index = Random.Range(0,enemyPrefabs.Count);
        return enemyPrefabs[index];
    }

    public int GetEnemyPrefabCount()
    {
        return enemyPrefabs.Count;
    }

    public List<Transform> GetWaypoints()
    {
        var waveWaypoints = new List<Transform>();

        foreach (Transform waypoint in pathPrefab.transform)
        {
            waveWaypoints.Add(waypoint);
        }

        Debug.Log(waveWaypoints.Count);
        return waveWaypoints;
    }

    public float GetTimeBetweenSpawns()
    {
        return timeBetweenSpawns;
    }

    public float GetSpawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetNumberOfEnemies()
    {
        return numberOfEnemies;
    }

    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public float GetRandomTime()
    {
        float RandomTime = Random.Range(timeBetweenSpawns - spawnRandomFactor, timeBetweenSpawns + spawnRandomFactor);

        return Mathf.Clamp(RandomTime,MinSpawnTime,float.MaxValue);
    }
}
