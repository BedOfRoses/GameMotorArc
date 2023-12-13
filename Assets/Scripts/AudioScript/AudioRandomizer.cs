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

        if (random > 33)
            audioSource.clip = audioClips[0]; // set to first song
        

        audioSource.clip = random is >= 33 and < 66 ? audioClips[1] : // set to second song
            audioClips[2]; // set to third song
        
        audioSource.Stop();
        audioSource.Play();
        
    }
}
