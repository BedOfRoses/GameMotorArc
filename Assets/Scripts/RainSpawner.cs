using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{
    
     /*
    The main objective of this class is to both manage how many raindrops is spawned,
    but also in "pooling" them and making the physicsmaterial slippery.
    
    So:
    1. Spawn raindrops
    2. Find out if many are together and increase the slipperyness
    
    Ideas:
    Use some kind of noise map to make some parts of a mesh more slippery?
    if vehicle.pos == noise-map-tile[i].pos
    slippery() = true; // this makes the car feel more slippery.
    
     */

     [SerializeField] private GameObject[] raindrop; // Array for the raindrops

     [SerializeField] private float MaxAmountOfRaindrops;

     private void Awake()
     {
        /*
         * Instantiate the amount of raindrops required.
         * **POSSIBLY MAKE THE RAINDROPS SPAWN BY couroutine to keep the spawning going
         * in that case move it into update
         */
        
        
        
         
     }
     
     
     
}
