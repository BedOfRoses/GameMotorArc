using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    
    [SerializeField] private SpringJoint sj;


    private void Awake()
    {
       //  sj = GetComponent<SpringJoint>();
// 
       //  sj.maxDistance = 0.6f;
       //  sj.damper = 0.1f;
       //  sj.autoConfigureConnectedAnchor = true;

    }

    private void FixedUpdate()
    {
        //
        //
        //
    }
}
