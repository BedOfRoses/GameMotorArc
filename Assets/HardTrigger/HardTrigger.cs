using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class HardTrigger : MonoBehaviour
{
    
    public Rigidbody playerBall;
    [SerializeField] private float fStrength = 34f;
    [SerializeField] private HUD hud;

    private void OnCollisionEnter(Collision other)
    {

        hud.AddScore(10000);
        
        Random random = new Random();
        float rand = random.Next(-51, 51);
        
        if (playerBall)
            playerBall.AddForce(0,-playerBall.position.y,rand, ForceMode.Impulse);
        
        
    }


   
}
