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
    }


    private void FixedUpdate()
    {
        
        // Accel forward logic
        CurrentAccel = ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0)) * accel;
        
        Currentbreakforce = Input.GetKey(KeyCode.Space) ? breakforce : 0;
        
        currentDegree = maxDegree * ((Input.GetKey(KeyCode.A) ? 1 : 0) - (Input.GetKey(KeyCode.D) ? 1 : 0));
        Debug.Log("currentdeggree" + currentDegree);
        
        foreach (var wCollider in _WheelColliders)
        {
            // Accel on all wheels, so its 4 drive
            wCollider.motorTorque = (float)CurrentAccel;
            wCollider.brakeTorque = (float)Currentbreakforce;
            wCollider.steerAngle = (float)currentDegree;
        }






    }
    
    
    
    
    //TODO: could be fun to implement 4-wheels-drive, front-only, back-only 

    
    
    
    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
