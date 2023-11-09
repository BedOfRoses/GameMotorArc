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


    private void SetUpSpringComp()
    {
        foreach (var wheel in wheels)
        {
            // Add the spring component
            wheel.AddComponent<SpringJoint>();

            // Set the connectedBody to the Car's body
            wheel.GetComponent<SpringJoint>().connectedBody = this.transform.gameObject.GetComponent<Rigidbody>();
            wheel.GetComponent<SpringJoint>().damper = 0.2f;
            wheel.GetComponent<SpringJoint>().maxDistance = 0f;
            wheel.GetComponent<SpringJoint>().minDistance = 0f;
            wheel.GetComponent<SpringJoint>().breakForce = Single.PositiveInfinity;
            wheel.GetComponent<SpringJoint>().breakTorque = Single.PositiveInfinity;
            
            wheel.GetComponent<SpringJoint>().autoConfigureConnectedAnchor = true;
            wheel.GetComponent<SpringJoint>().enableCollision = true;
            wheel.GetComponent<SpringJoint>().spring = 10;
            wheel.GetComponent<SpringJoint>().enablePreprocessing = true;


            wheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX;
            wheel.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionZ;


        }
        
        
    }
    
    private void Awake()
    {
        
        SetUpSpringComp();
        
       
    }


    void MoveFunction()
    {


        if (Input.GetKey(KeyCode.A))
        {
            // add force left
        }

        if (Input.GetKey(KeyCode.D))
        {
            // add force right
        }

        if (Input.GetKey(KeyCode.W))
        {
            // add force forward
        }

        if (Input.GetKey(KeyCode.S))
        {
            // add force backwards
        }
        
        
        
        
    }
    
    
    
    private void FixedUpdate()
    {
        //TODO: IMPLEMENT LATER
       // RaycastHit hit;
       // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
       // {
       //     
       // }
       
       
       
        
    }
    
    
   
    
    
    
}
