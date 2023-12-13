using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRandomizer : MonoBehaviour
{
    
    // Just randomize which song to play when starting the game

    public AudioClip[] audioClips;

    public AudioSource audioSource;
    
    private void Awake()
    {


        float random = UnityEngine.Random.Range(0, 100);

        audioSource.clip = random switch
        {
            < 33 => audioClips[0],
            >= 33 and < 66 => audioClips[1],
            _ => audioClips[2]
        };

        audioSource.Stop();
        audioSource.Play();
        
    }
}
