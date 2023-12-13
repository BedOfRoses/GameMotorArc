using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TruckV2 : MonoBehaviour
{
    
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


    [SerializeField] private Rigidbody rb;


    #region Experimental Upside down Variables
    // This was meant to help the player in case they fall upside down
    [SerializeField] private float upsideDownDistance = 3f;
    [SerializeField] private float TimeUpsideDownMax = 3f;
    [SerializeField] private float TimeUpsideDownCurrent = 0f;
    #endregion
    
    // Lists for Colliders and Transforms
    [SerializeField] private List<Transform> _WheelTransforms;
    [SerializeField] private List<WheelCollider> _WheelColliders;

    
    // Setting float variables for acceleration
    [SerializeField] private double accel =  800.300;
    [SerializeField] private double breakforce = 505.405;
    [SerializeField] private double CurrentAccel = default;
    [SerializeField] private double Currentbreakforce = default;

    /* For turning */
    [SerializeField] private double currentDegree = default;
    [SerializeField] private double maxDegree = 37.6;
    [SerializeField] private double turnSpeed = 15;

    // Reset positions
    private Transform startRot;
    private Quaternion endRot;

    #region StateMachineStuff

    public bool IsMoving;
    public bool IsBreaking;

    public TruckStateMachine truckStateMachine;
    public TMP_Text stateText;
    
    #endregion



    public bool bFunMode = true;
    public Camera mainCamera;
    
    // For safety if we tip upside down
    [SerializeField] private Vector3 spawnPos;
    [SerializeField] private Quaternion spawnRot;


    void ResetPosition()
    {
        transform.position = spawnPos;
        transform.rotation = spawnRot;
    }
    
    
    private void Awake()
    {
        
        // Create and initialize the state
        truckStateMachine = new TruckStateMachine(this);
        truckStateMachine.Initialize(truckStateMachine._idleState); // initialize as idle

        // Save the given spawn location of our vehicle as a reset point.
        var transform1 = transform;
        spawnPos = transform1.position;
        spawnRot = transform1.rotation;
        
        // Push all the colliders into the List
        _WheelColliders.Add(frontLeftWheelCollider);
        _WheelColliders.Add(frontRightWheelCollider);
        _WheelColliders.Add(backLeftWheelCollider);
        _WheelColliders.Add(backRightWheelCollider);
        
        // Add Transforms to our list of wheeltransforms
        _WheelTransforms.Add(frontLeftWheelTransform);
        _WheelTransforms.Add(frontRightWheelTransform);
        _WheelTransforms.Add(backLeftWheelTransform);
        _WheelTransforms.Add(backRightWheelTransform);
        
    }


    private void FixedUpdate()
    {

        // Update camera to look at our vehicle
        if (mainCamera)
            mainCamera.transform.LookAt(transform.position);
        
        // State machine update and text update to let us know what state we're in!
        truckStateMachine.Update();
        stateText.text = truckStateMachine.CurrentState.ToString();

        //TODO: I dont think this will work :(
        // if (isUpsideDown())
        // {
        //     TimeUpsideDownCurrent += Time.fixedDeltaTime;
        //     Debug.Log("TimeUpsideDown: " + TimeUpsideDownCurrent);
        // }
        // else
        // {
        //     Debug.Log("Stopped counting");
        //     TimeUpsideDownCurrent = 0;
        // }
        //
        //
        // if (isUpsideDown() && TimeUpsideDownCurrent >= TimeUpsideDownMax) // We are upside down and we have been for this certain amount of time
        // {
        //     Debug.Log("We met the threshhold and are now resetting");
        //     transform.position = spawnPos;
        //     transform.rotation = spawnRot;
        // }


        if (Input.GetKey(KeyCode.R))
        {
            ResetPosition();
        }
        
        // Accelerate forward logic / backwards
        CurrentAccel = ((Input.GetKey(KeyCode.W) ? 1 : 0) - (Input.GetKey(KeyCode.S) ? 1 : 0)) * accel; //gives either 1, 0 or -1
        
        // break
        Currentbreakforce = Input.GetKey(KeyCode.Space) ? breakforce : 0; // either breakforce or 0
        
        // turn left and right
        currentDegree = maxDegree * ((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)); //gives either 1, 0 or -1 times the amount of degrees. 
        
        // double rotationAmount = maxDegree * currentDegree / maxDegree; // Was used for debugging and testing/experimenting
        
        foreach (var wCollider in _WheelColliders)
        {
            // Accel on all wheels, so its bascially 4-drive
            wCollider.motorTorque = (float)CurrentAccel; // The torque applied to rotate wheel in the given directions
            wCollider.brakeTorque = (float)Currentbreakforce; // The force to slow the wheels rotation
            // wCollider.steerAngle = (float)currentDegree; // This sets every wheel to turn, basically we just steer sideways. No turning with this on
        }

        // Front wheels to turn
        frontLeftWheelCollider.steerAngle = (float)currentDegree;
        frontRightWheelCollider.steerAngle = (float)currentDegree;
        
        // Update transforms
        if (bFunMode)
        {
            WheelRotUpdate(frontLeftWheelCollider,frontLeftWheelTransform);
            WheelRotUpdate(frontRightWheelCollider,frontRightWheelTransform);
            WheelRotUpdate(backLeftWheelCollider,backLeftWheelTransform);
            WheelRotUpdate(backRightWheelCollider,backRightWheelTransform);
        }
        else
        {
            for (int i = 0; i < _WheelTransforms.Count; i++)
            {
                _WheelTransforms[i].localRotation = Quaternion.Euler(
                    _WheelTransforms[i].localEulerAngles.x,
                    _WheelColliders[i].steerAngle,
                    _WheelTransforms[i].localEulerAngles.z);
            }
        }
        
        
        
        // Statemachine info stuff
        IsMoving = rb.velocity.magnitude >= 0.02f;
        IsBreaking = Currentbreakforce > 0;
        


    }


    bool isUpsideDown()
    {
        // This function helps us detect if we are upside down
        return Physics.Raycast(transform.position, -transform.up , upsideDownDistance);
    }
    

    public void WheelRotUpdate(WheelCollider wColl, Transform tf)
    {
        // Variables for rotation and position
        Vector3 pos;
        Quaternion rot;
        
        // Extract world position and rotation from collider
        wColl.GetWorldPose(out pos, out rot);

        // Update the position and rotation the same as collider.
        tf.position = pos;
        tf.rotation = rot;
    }


    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
