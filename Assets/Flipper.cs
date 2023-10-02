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
   
   [SerializeField] private HUD hud;
   
    private void Start()
    {
        leftFlipper.useSpring = true;
        rightFlipper.useSpring = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        hud.AddScore(9398);
    }

    private void FixedUpdate()
    {

        JointSpring leftSpring = new JointSpring();
        leftSpring.spring = flipStrength;
        leftSpring.damper = dampStrength;


        JointSpring rightSpring = new JointSpring();
        rightSpring.spring = flipStrength;
        rightSpring.damper = dampStrength;
        

        
        if (Input.GetKey(KeyCode.A))
        {
            //Left
            leftSpring.targetPosition = leftTargetPos;

        }
        else
        {
            leftSpring.targetPosition = leftRestPos;
        }

        if (Input.GetKey(KeyCode.D))
        {
            // swing oppover for hinge2
            rightSpring.targetPosition = RightTargetPos;
        }
        else
        {
            rightSpring.targetPosition = rightRestPos;
        }

        rightFlipper.spring = rightSpring;
        rightFlipper.useLimits = true;
        leftFlipper.spring = leftSpring;
        leftFlipper.useLimits = true;

    }
}
