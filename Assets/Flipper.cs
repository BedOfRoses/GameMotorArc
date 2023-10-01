using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    
    public HingeJoint hinge;
    public Rigidbody cringe;
    
    private void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.A))
        {
            // swing oppover for hinge1
            hinge.connectedBody.freezeRotation = true;
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            // swing oppover for hinge2
        }
        
        
    }
}
