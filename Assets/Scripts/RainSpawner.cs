using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
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

     /* The prefabs that are spawned into this horrible world (simulation) . How does this raindrop not know if it's world is fake,
      how do i know if my world is real and not fake */
     [SerializeField] private List<GameObject> raindropsList; // Array for the raindrops

     [SerializeField] private GameObject rainPrefab;
     
     /* Start amount */
     [SerializeField] private float StartAmountOfRain;
     
     /* Max amount of entities*/
     [SerializeField] private float MaxAmountOfRaindrops;

     
     
     [SerializeField] private bool bIsRaining = true;


     /* The purpose of this function is to enable or disable rain function */
     public bool bRainEnabled
     {
         get
         {
             return bIsRaining;
         }

         set
         {
             bIsRaining = value;
         }
         
     }
     
     
     private void Awake()
     {
        /*
         * Instantiate the amount of raindrops required.
         * **POSSIBLY MAKE THE RAINDROPS SPAWN BY couroutine to keep the spawning going
         * in that case move it into update
         */
        
        
        
         
     }

     public void FixedUpdate()
     {
         
         if (bRainEnabled)
         {
             /* Rain logic */
             
             /*
              * Spawn raindrop
              * Set the spawn/death time for this particle/entity
              * Destroy after given time
              * 
              */
             
             
             // Instantiate(rainPrefab, new Vector3(0, 3, 0), Quaternion.identity);
            //raindropsList.Add(Instantiate(rainPrefab, new Vector3(0, 3, 0), Quaternion.identity));

            var rainspawned = Instantiate(rainPrefab, new Vector3(0, 3, 0), Quaternion.identity);
            raindropsList.Add(rainspawned);
         }
         
         DestroyRainDrop();
         
         
     }


     public void OnCollisionEnter(Collision other)
     {
         /*If the other collision is the floor, increase the physics mat ground */
         
         //TODO GIVE BETTER NAME BLYAT
         if (other.gameObject.name == "floor" && other.gameObject != null)
         {
             //ok we hit the ground, now we increase this floor's physics material

             var otherGameObject = other.gameObject;
             
             otherGameObject.GetComponent<PhysicMaterial>().dynamicFriction += 1f;
             otherGameObject.GetComponent<PhysicMaterial>().staticFriction += 1f;
             

         }
         
         
         
     }


     public void DestroyRainDrop()
     {
         foreach (var raindrop in raindropsList)
         {
             Destroy(raindrop, 0.4f);
         }
     }
     
     
     
     
     
     
     
} // End /////////////////////////////////////////////////////////////////////////////////////////////////////////////
