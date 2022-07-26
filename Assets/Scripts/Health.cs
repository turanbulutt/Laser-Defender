using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("General")]
    [SerializeField] bool isPlayer;
    [SerializeField] bool applyCameraShake;
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] int score = 50;
    [SerializeField] LevelManager sceneLoader;

    CameraShake shake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    Enable enable;
    
    void Awake()
    {
        enable = FindObjectOfType<Enable>();
        
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        shake = Camera.main.GetComponent<CameraShake>();
    }
    private void Start()
    {
        if(isPlayer)
            enable.SetDisable();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            HitEffect();
            CameraShake();
            PlayAudio();
            damageDealer.Hit();
        }

    }

    private void PlayAudio()
    {
        audioPlayer.PlayDamageTakenClip();
    }

    private void CameraShake()
    {
        if (shake != null && applyCameraShake)
            shake.Play();
    }

    private void HitEffect()
    {
        if(hitEffect!=null)
        {
            ParticleSystem effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect.gameObject,effect.main.duration);
            

        }
        
    }

    private void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
            if(!isPlayer)
                UpdateScore();
            else
            {
                sceneLoader.LoadEndGame();
                enable.SetEnable();
            }
                
        }

    }

    private void UpdateScore()
    {
        scoreKeeper.ChangeScore(score);
    }

    public int GetHealth()
    {
        return health;
    }
}
