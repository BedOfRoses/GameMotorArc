using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumTrigger : MonoBehaviour
{

    [SerializeField] private float fStrength = default;

    public Rigidbody playerBall;
    

    private void OnCollisionEnter(Collision other)
    {
        if (playerBall)
        {
            playerBall.AddForce(-playerBall.position, ForceMode.Impulse);
        }
    }
}
