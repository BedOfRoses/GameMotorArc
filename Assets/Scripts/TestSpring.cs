using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpring : MonoBehaviour
{

    // SOURCES: https://youtu.be/LIUbsijY_2E?feature=shared

    [SerializeField] private float length = 3f;
    [SerializeField] private float strength = 1f;
    [SerializeField] private Rigidbody rb;

    private float lastHit;
    private void FixedUpdate()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(-Vector3.up), out hit, length))
        {
            float forceAmount = 0;
            forceAmount = strength * (length - hit.distance) / length;
            rb.AddForceAtPosition(transform.up * forceAmount, transform.position);
            
        }
        

    }
    
    
    
} ////////////////////////////////////////////////////////////////////////////////////////////
