using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager sm;
    public AudioSource audioSource;
    public AudioClip starSound, diamondSound, gameOverSound;

    private void Awake()
    {
        if(sm == null)
        {
            sm = this;
        }
    }

    public void StarSound()
    {
        audioSource.clip = starSound;
        audioSource.Play();
    }

    public void DiamondSound()
    {
        audioSource.clip = diamondSound;
        audioSource.Play();
    }

    public void GameOverSound()
    {
        audioSource.clip = gameOverSound;
        audioSource.Play();
    }
}
