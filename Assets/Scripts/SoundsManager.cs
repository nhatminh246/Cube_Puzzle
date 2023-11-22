using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static SoundsManager Instance;
    public AudioSource audioSource;
    public AudioClip bgm ;
    public AudioClip[] gore;
    public AudioClip[] enemyDie;
    public AudioClip[] enemyGored;
    public AudioClip[] stoneMove;

    public AudioClip[] stoneGored;

    public AudioClip win;

    public AudioClip buttonClick;
    public AudioClip pickKey;
    public AudioClip openChess;
    public AudioClip spikeDamage;


    void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayOneShotAudioGore()
    {
        audioSource.PlayOneShot(gore[Random.Range(0, gore.Length)]);
    }

    public void PlayOneShotAudioStoneMove()
    {
        audioSource.PlayOneShot(stoneMove[Random.Range(0, stoneMove.Length)]);
    }
    public void PlayOneShotAudioStoneGored()
    {
        audioSource.PlayOneShot(stoneGored[Random.Range(0, stoneGored.Length)]);
    }
    public void PlayOneShotAudioEnemyGored()
    {
        audioSource.PlayOneShot(enemyGored[Random.Range(0, enemyGored.Length)]);
    }
    public void PlayOneShotAudioEnemyDie()
    {
        audioSource.PlayOneShot(enemyDie[Random.Range(0, enemyDie.Length)]);
    }
    public void PlayOneShotAudioButtonClick()
    {
        audioSource.PlayOneShot(buttonClick);
    }
    public void PlayOneShotAudioWin()
    {
        audioSource.PlayOneShot(win);
    }
    public void PlayOneShotAudioPickKey()
    {
        audioSource.PlayOneShot(pickKey);
    }
    public void PlayOneShotAudioOpenChess()
    {
        audioSource.PlayOneShot(openChess);
    }
    public void PlayOneShotAudioSpikeDamage()
    {
        audioSource.PlayOneShot(spikeDamage);
    }
    // Update is called once per frame

}
