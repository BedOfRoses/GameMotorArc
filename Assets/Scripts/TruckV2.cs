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

        if (Input.GetKey(KeyCode.A))
            CurrentAccel = accel * -1;
        else
            CurrentAccel = 0;
        

        if (Input.GetKey(KeyCode.D))
            CurrentAccel = accel * 1;
        else
            CurrentAccel = 0;
        
        
        if (Input.GetKey(KeyCode.S)) // We are breaking
            Currentbreakforce = breakforce;
        else
            Currentbreakforce = 0; // we are not breaking
        
        
        foreach (var wCollider in _WheelColliders)
        {
            // Accel on all wheels, so its 4 drive
            wCollider.motorTorque = (float)CurrentAccel;
            wCollider.brakeTorque = (float)Currentbreakforce;
        }
        
        
        
        
        
  
    }
    
    
    
    
    //TODO: could be fun to implement 4-wheels-drive, front-only, back-only 

    
    
    
    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
