using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

    [SerializeField] private GameObject[] wheels;
    [SerializeField] private float k; // spring-constant
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 F; // sum of Forces or more commonly known as Force
    [SerializeField] private Vector3 W; // work.
    [SerializeField] private float distance;
    [SerializeField] private float length;

    private void Awake()
    {
       
    }
    
    
    
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
        {
            
        }
        
    }
    
    
    void test()
    {
        
        Vector3 force1 = new Vector3(1, 1, 1);
        Vector3 force2 = new Vector3(2, 2, 2);
        Vector3 sum = force1 + force2;
        Debug.Log("Sum of force is: " + sum.ToString("F2"));
        
        Vector3 newforce = new Vector3();
        rb.AddForce(newforce,ForceMode.Acceleration);
    }
    
    
    
}
