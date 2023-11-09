using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckV2 : MonoBehaviour
{

    // [SerializeField] private List<GameObject> WheelPrefabs;

    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backLeft;
    [SerializeField] private WheelCollider backRight;


    [SerializeField] private double accel;
    [SerializeField] private double breakforce;
    [SerializeField] private double CurrentAccel = default;
    [SerializeField] private double Currentbreakforce = default;


    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.S)) 
            Currentbreakforce = breakforce;
        else
            Currentbreakforce = 0;



    }
    
    
    
    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
