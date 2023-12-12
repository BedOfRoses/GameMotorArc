using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    
    public Transform tf;
    public Rigidbody rb;
    public float distanceToTheGround = 2f;
    
    
    
    public void FixedUpdate()
    {
        if (!hitGround())
        {
            rb.AddForce(Vector3.up,ForceMode.Force);
        }
    }

    bool hitGround()
    {
        return Physics.Raycast(transform.position, Vector3.down, distanceToTheGround);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * distanceToTheGround);
        
    }
    
    
    
}
