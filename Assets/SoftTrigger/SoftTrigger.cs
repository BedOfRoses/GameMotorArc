using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoftTrigger : MonoBehaviour
{
    
    public Rigidbody playerBall;
    [SerializeField] private float fStrength = 10f;
    
    
    private void OnCollisionEnter(Collision other)
    {
        if (playerBall)
            playerBall.velocity = new Vector3(0,  -(playerBall.velocity.y) * fStrength, 0);
    }
    
}

