using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumTrigger : MonoBehaviour
{

    
    public Rigidbody playerBall;
    [SerializeField] private float fStrength = default;

    private void OnCollisionEnter(Collision other)
    {
        if (playerBall)
            playerBall.AddForce(-playerBall.position, ForceMode.Impulse);
        
        // if (playerBall)
        //     playerBall.velocity = new Vector3(0,  -(playerBall.velocity.y) * fStrength, 0);
    }
    
    
    
}
