using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    
   [SerializeField] public HingeJoint leftFlipper;
   [SerializeField] public HingeJoint rightFlipper;
   
   [SerializeField] public float leftTargetPos;
   [SerializeField] public float leftRestPos = 0;
   [SerializeField] public float RightTargetPos;
   [SerializeField] public float rightRestPos = 0;

   [SerializeField] private float maxPos;
   [SerializeField] private float startPos;
   [SerializeField] private float flipStrength;
   [SerializeField] private float dampStrength;
   

    private void Start()
    {
        leftFlipper.useSpring = true;
        rightFlipper.useSpring = true;
    }

    private void FixedUpdate()
    {
        var leftFlipperSpring = leftFlipper.spring;
        leftFlipperSpring.spring = flipStrength;
        
        
        var rightFlipperSpring = rightFlipper.spring;
        rightFlipperSpring.spring = flipStrength;
        
        
        leftFlipperSpring.damper = dampStrength;
        rightFlipperSpring.damper = dampStrength;

        
        if (Input.GetKey(KeyCode.A))
        {
            //Left
            leftFlipperSpring.targetPosition = leftTargetPos;
            leftFlipper.spring = leftFlipperSpring;
            rightFlipper.useLimits = true;

        }

        if (Input.GetKey(KeyCode.D))
        {
            // swing oppover for hinge2
            rightFlipperSpring.targetPosition = RightTargetPos;
            rightFlipper.spring = rightFlipperSpring;
            rightFlipper.useLimits = true;
        }

        leftFlipperSpring.targetPosition = leftRestPos;
        rightFlipperSpring.targetPosition = rightRestPos;

    }
}
