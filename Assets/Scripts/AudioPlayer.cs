using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField][Range(0f,1f)] float shootingVolume = 1f;

    [Header("Enemy Shooting")]
    [SerializeField] AudioClip EnemyshootingClip;
    [SerializeField] [Range(0f, 1f)] float EnemyshootingVolume = 1f;

    [Header("Damage Taken")]
    [SerializeField] AudioClip damageTakenClip;
    [SerializeField] [Range(0f, 1f)] float damageTakenVolume = 1f;


    public void PlayShootingClip()
    {
        if(shootingClip!=null)
        {
            PlayClip(shootingClip, shootingVolume);
        }
    }

    public void PlayEnemyShootingClip()
    {
        if (EnemyshootingClip != null)
        {
            PlayClip(EnemyshootingClip, EnemyshootingVolume);
        }
    }

    public void PlayDamageTakenClip()
    {
        if(damageTakenClip!=null)
        {
            PlayClip(damageTakenClip, damageTakenVolume);
        }
    }

    private void PlayClip(AudioClip clip,float volume)
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, volume);
    }
}
