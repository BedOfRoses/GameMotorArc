using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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


    [SerializeField] private Rigidbody rb;


    [SerializeField] private float upsideDownDistance = 3f;
    [SerializeField] private float TimeUpsideDownMax = 3f;
    [SerializeField] private float TimeUpsideDownCurrent = 0f;
    
    
    [SerializeField] private List<Transform> _WheelTransforms;
    [SerializeField] private List<WheelCollider> _WheelColliders;

    [SerializeField] private double accel =  800.300;
    [SerializeField] private double breakforce = 505.405;
    [SerializeField] private double CurrentAccel = default;
    [SerializeField] private double Currentbreakforce = default;

    /* For turning */
    [SerializeField] private double currentDegree = default;
    [SerializeField] private double maxDegree = 37.6;
    [SerializeField] private double turnSpeed = 15;

    private Quaternion startRot;
    private Quaternion endRot;

    #region StateMachineStuff

    public bool IsMoving;
    public bool IsBreaking;

    public TruckStateMachine truckStateMachine;
    public TMP_Text stateText;
    
    #endregion


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
        
        // Set the state
        truckStateMachine = new TruckStateMachine(this);
        truckStateMachine.Initialize(truckStateMachine._idleState); // initialize as idle


        var transform1 = transform;
        spawnPos = transform1.position;
        spawnRot = transform1.rotation;
        
        // Push all the colliders into the List
        _WheelColliders.Add(frontLeftWheelCollider);
        _WheelColliders.Add(frontRightWheelCollider);
        _WheelColliders.Add(backLeftWheelCollider);
        _WheelColliders.Add(backRightWheelCollider);
        
        // Transforms
        _WheelTransforms.Add(frontLeftWheelTransform);
        _WheelTransforms.Add(frontRightWheelTransform);
        _WheelTransforms.Add(backLeftWheelTransform);
        _WheelTransforms.Add(backRightWheelTransform);
        
       
        Debug.Log("Transehjul init");
        foreach (var transehjula in _WheelTransforms)
        {
            transehjula.transform.ToString();
        }
        
        
    }


    private void FixedUpdate()
    {

        if (mainCamera)
            mainCamera.transform.LookAt(transform.position);
        
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
        currentDegree = maxDegree * ((Input.GetKey(KeyCode.D) ? 1 : 0) - (Input.GetKey(KeyCode.A) ? 1 : 0)); //gives either 1, 0 or -1
        
        double rotationAmount = maxDegree * currentDegree / maxDegree;
        
        foreach (var wCollider in _WheelColliders)
        {
            // Accel on all wheels, so its bascially 4-drive
            wCollider.motorTorque = (float)CurrentAccel;
            wCollider.brakeTorque = (float)Currentbreakforce;
            // wCollider.steerAngle = (float)currentDegree; // This sets every wheel to turn, basically we just steer sideways. No turning with this on
        }

        // Front wheels to turn
        frontLeftWheelCollider.steerAngle = (float)currentDegree;
        frontRightWheelCollider.steerAngle = (float)currentDegree;
        
        // Update transforms
        WheelRotUpdate(frontLeftWheelCollider,frontLeftWheelTransform);
        WheelRotUpdate(frontRightWheelCollider,frontRightWheelTransform);
        WheelRotUpdate(backLeftWheelCollider,backLeftWheelTransform);
        WheelRotUpdate(backRightWheelCollider,backRightWheelTransform);
        

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
        Vector3 pos;
        Quaternion rot;
        wColl.GetWorldPose(out pos, out rot);

        tf.position = pos;
        tf.rotation = rot;
    }


    
}///////////////// END ///////////////////////////////////////////////////////////////////////////////////////////////////////// 
