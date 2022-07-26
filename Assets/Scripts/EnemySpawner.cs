using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfig> waveConfigs;
    [SerializeField] float WaitingTimeBetweenWaves = 5f;
    [SerializeField] float waitingRandomFactor = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExecuteWaves());

    }

    private IEnumerator ExecuteWaves()
    {
        foreach (var currentWave in waveConfigs)
        {
            StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitForSeconds(10);
        }
        while (true)
        {
            int index = (int)Random.RandomRange(0f, waveConfigs.Count);
            StartCoroutine(SpawnAllEnemiesInWave(waveConfigs[index]));
            yield return new WaitForSeconds(GetRandomTime());
        }
       
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig waveConfig)
    {

        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newEnemy = Instantiate(waveConfig.GetRandomEnemy(), waveConfig.GetWaypoints()[0].transform.position, Quaternion.identity, transform);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(waveConfig.GetRandomTime());
        }

    }

    public float GetRandomTime()
    {
        float RandomTime = Random.Range(WaitingTimeBetweenWaves - waitingRandomFactor, WaitingTimeBetweenWaves + waitingRandomFactor);

        return RandomTime;
    }

}
