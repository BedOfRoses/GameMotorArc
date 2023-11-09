using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Truck : MonoBehaviour
{

    [SerializeField] private GameObject[] wheels;
    [SerializeField] private GameObject[] Knobs;
    [SerializeField] private float k; // spring-constant
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 F; // sum of Forces or more commonly known as Force
    [SerializeField] private Vector3 W; // work.
    [SerializeField] private float distance;
    [SerializeField] private float length;
    [SerializeField] private float strength;


    [SerializeField] private bool greenKnbobbdy = true;
    [SerializeField] private bool blueknobby;
    
    [SerializeField] private float maxDist = 0.9f;
 
 
   
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
       
       
       // CalculateSpring();
       Suspension();
        
    }



    // private void CalculateSpring()
    // {
    //
    //     foreach (var wheel in wheels)
    //     {
    //
    //         RaycastHit hit;
    //         // if the wheel hits the ground or will repel a force 
    //         if (Physics.Raycast(wheel.transform.position, wheel.transform.TransformDirection(Vector3.down), out hit,
    //                 length))
    //         {
    //             var fAm = ForceAmount(strength, length,hit);
    //             
    //             wheel.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(transform.up * fAm, transform.position);
    //             
    //             // fAm = 3 * length
    //             
    //         }
    //         //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, length))
    //         //{
    //         //}
    //
    //     }
    //     
    //     
    // }



    public void Suspension()
    {
        
        // SOURCES https://www.youtube.com/watch?v=LG1CtlFRmpU
        
        /* Add to the bottom corners of the vehicle body, these are the Knobs */
        /* This way it is "pushing" itself up off the ground just like actual wheels would */
        
        /* To do this, every frame we perform a raycast from each of the bottom corner of the box
         - so the front left, front right , the back left, the back right 
         - going downwards in the local vehicle space for the length of the suspension , in space game about 60cm
         */
        
        /*For the raycast
         if the raycast doesnt hit anything, then the suspension is fully extended so we dont need to do anything,
         we can let the physics continue simulating
         but if it hits something
         we can calculate the compression ratio of that suspension as a number between 0 and 1.
         
         so 0 means its fully extended - it hasnt hit anything - and 1 means it is fully compressed so its at where the raycast was started
         
         Then all we need to do is add an upwards force on the box at the appropriate position using the physics engine.
         We scale this upwards force by the compression ratio, so basically more force acts on the vehicle as the suspension compresses more.
         
         */
        
        // Going through each of the knobs
        foreach (var knob in Knobs)
        {

            float compressionRatio; // the distance between the ground we hit with ray cast, and our max distance

            RaycastHit hit = default;
            // from the knob looking straight down.
            if (Physics.Raycast(knob.transform.position, knob.transform.TransformDirection(Vector3.down), maxDist))
            {
                
               // WE DONT WANT TO USE THE RIGID BODY OF THE KNOBS.

                float hitDist = hit.distance;

                compressionRatio = 1 - (hit.distance / maxDist); // This gives us the ratio of compression force

                Debug.Log("compressRate: "+ compressionRatio);
                
                Vector3 UpForce = Vector3.up * (compressionRatio * k);

                
               if(greenKnbobbdy)
                   Debug.DrawRay(knob.transform.position, knob.transform.TransformDirection(Vector3.down) * maxDist, Color.green);
               
               
            }
            else
            {
                // fully extended
                Debug.Log("Wheel suspension is fully extended");
            }


        }
        
        
        
    }



    private float ForceAmount(float strengf, float lengf, RaycastHit hit)
    {

        // var forzamo = strengf * (lengf - Mathf.Pow(hit.distance, 2f) / lengf) / lengf;
        var bingo = (Mathf.Pow(lengf - hit.distance, 2f) / lengf * strengf) / lengf;
        return bingo;
    }


   
} // end ///////////////////////////////////////////////////////////



/////////////////////////////////////////////////////////////////////////////// OLD BACKUP / TEMP
//float hitDist = hit.distance;
                
// compressionRatio = 1 - (hit.distance / maxDist); // This gives us the ratio of compression force
//
// Debug.Log("compressRate: "+ compressionRatio);
// Vector3 UpForce = Vector3.up * (compressionRatio * k); // 
//                 
//                 
// knob.gameObject.GetComponent<Rigidbody>().AddForceAtPosition(UpForce,knob.transform.position);
//                 
// // rb.AddForceAtPosition(Vector3.up*3f,knob.transform.position);
//
// if(greenKnbobbdy)
//     Debug.DrawRay(knob.transform.position, knob.transform.TransformDirection(Vector3.down) * maxDist, Color.green);
// if(blueknobby)
//     Debug.DrawRay(knob.transform.position, knob.transform.TransformDirection(Vector3.down) * hit.distance, Color.blue);
//
// rb.AddForceAtPosition(UpForce, transform.position);