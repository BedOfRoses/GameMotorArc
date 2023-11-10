using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckV2 : MonoBehaviour
{

    // [SerializeField] private List<GameObject> WheelPrefabs;

    #region WheelColliders
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider backLeftWheelCollider;
    [SerializeField] private WheelCollider backRightWheelCollider;
    #endregion

    #region WheelTransforms
    [SerializeField] private Transform frontRightWheelTransform;
    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform backLeftWheelTransform;
    [SerializeField] private Transform backRightWheelTransform;
    #endregion

    [SerializeField] private List<Transform> _WheelTransforms;
    
    [SerializeField] private List<WheelCollider> _WheelColliders;

    [SerializeField] private double accel =  800.300;
    [SerializeField] private double breakforce = 505.405;
    [SerializeField] private double CurrentAccel = default;
    [SerializeField] private double Currentbreakforce = default;

    /* For turning */
    [SerializeField] private double currentDegree = default;
    [SerializeField] private double maxDegree = 37.6;
    
    
    
    private void Awake()
    {
        
        // Push all the colliders into the List
        _WheelColliders.Add(frontLeftWheelCollider);
        _WheelColliders.Add(frontRightWheelCollider);
        _WheelColliders.Add(backLeftWheelCollider);
        _WheelColliders.Add(backRightWheelCollider);
        
        _WheelTransforms.Add(frontLeftWheelTransform);
        _WheelTransforms.Add(frontRightWheelTransform);
        _WheelTransforms.Add(backLeftWheelTransform);
        _WheelTransforms.Add(backRightWheelTransform);
        
    }


    private void FixedUpdate()
    {
        
        // Accelerate forward logic / backwards
        CurrentAccel = ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0)) * accel; //gives either 1, 0 or -1
        
        // break
        Currentbreakforce = Input.GetKey(KeyCode.Space) ? breakforce : 0; // either breakforce or 0
        
        // turn left and right
        currentDegree = maxDegree * ((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)); //gives either 1, 0 or -1
        
        foreach (var wCollider in _WheelColliders)
        {
            // Accel on all wheels, so its 4 drive
            wCollider.motorTorque = (float)CurrentAccel;
            wCollider.brakeTorque = (float)Currentbreakforce;
            wCollider.steerAngle = (float)currentDegree;


            #region Todo
            //TODO FIX THIS CODE :)
            // wCollider.transform.localScale = Vector3.one;
            // Vector3 position = default;
            // Quaternion rotation = default;
            // wCollider.GetWorldPose(out position, out rotation);
            // //wCollider.transform.localScale = Vector3.one;
            // wCollider.transform.position = position;
            // wCollider.transform.rotation = rotation;
            

            #endregion
            
            


        }
        
        






    }
    
    
    
    
    //TODO: could be fun to implement 4-wheels-drive, front-only, back-only 

    
    
    
    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
