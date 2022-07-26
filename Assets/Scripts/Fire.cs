using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 4f;
    [SerializeField] float projectileFirePeriod = 0.3f;
    [SerializeField] float spawnRandomFactor = 0.1f;
    [SerializeField] float MinWaitingTime = 0.01f;
    [SerializeField] float MaxWaitingTime = 0.3f;

    AudioPlayer audioPlayer;

    private void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (CompareTag("1 laser"))
            StartCoroutine(FireContinuously());
        else if (CompareTag("2 laser"))
            StartCoroutine(FireContinuously2());
    }

    private IEnumerator FireContinuously2()
    {
        float waitTime = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            Vector2 pos = new Vector2(transform.position.x-0.3f, transform.position.y);
            GameObject laser = Instantiate(laserPrefab, pos, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

            pos = new Vector2(transform.position.x + 0.3f, transform.position.y);
            laser = Instantiate(laserPrefab, pos, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            PlayClip();
            yield return new WaitForSeconds(GetRandomTime());
        }
    }

    private IEnumerator FireContinuously()
    {
        float waitTime = Random.Range(0.1f, 1f);
        yield return new WaitForSeconds(waitTime);
        while (true)
        {
            Vector2 pos = new Vector2(transform.position.x, transform.position.y);
            GameObject laser = Instantiate(laserPrefab, pos, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
            PlayClip();
            yield return new WaitForSeconds(GetRandomTime());
        }

    }

    private void PlayClip()
    {
        audioPlayer.PlayEnemyShootingClip();
    }

    public float GetRandomTime()
    {
        float RandomTime = Random.Range(projectileFirePeriod - spawnRandomFactor, projectileFirePeriod + spawnRandomFactor);

        return Mathf.Clamp(RandomTime, MinWaitingTime, MaxWaitingTime);
    }
}
