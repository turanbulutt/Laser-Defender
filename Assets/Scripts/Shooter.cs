using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 5f;
    [SerializeField] float projectileFirePeriod = 0.1f;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    [HideInInspector]public bool isFiring;
    // Start is called before the first frame update
    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine==null)
            firingCoroutine = StartCoroutine(FireContinuosly());
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
            
    }

    IEnumerator FireContinuosly()
    {
        while (true)
        {
            GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity) as GameObject;
            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);
            audioPlayer.PlayShootingClip(); 
            yield return new WaitForSeconds(projectileFirePeriod);
        }
    }
}
