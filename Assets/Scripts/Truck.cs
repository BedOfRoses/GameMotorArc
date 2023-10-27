using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck : MonoBehaviour
{

    [SerializeField] private GameObject[] wheels;

    [SerializeField] private float k; // spring-constant

    [SerializeField] private Rigidbody rb; 


    void test()
    {
        Vector3 newforce = new Vector3();
        rb.AddForce(newforce,ForceMode.Acceleration);
        
    }
    
    private void FixedUpdate()
    {
        throw new NotImplementedException();
    }
}
