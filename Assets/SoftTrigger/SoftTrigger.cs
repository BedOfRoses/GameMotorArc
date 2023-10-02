using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = System.Random;

public class SoftTrigger : MonoBehaviour
{
    
    public Rigidbody playerBall;
    [SerializeField] private float fStrength = 10f;

    [SerializeField] private HUD hud;
    
    private void OnCollisionEnter(Collision other)
    {
        hud.AddScore(1000);

        Random random = new Random();

        float rand = random.Next(-101, 101);
        
        if (playerBall)
            playerBall.velocity = new Vector3(0,  -(playerBall.velocity.y) * fStrength, 0.1f * rand);
    }
    
}

