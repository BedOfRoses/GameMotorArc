using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SoftTrigger : MonoBehaviour
{
    
    // Reference to player
    public Rigidbody playerBall;

    private bool bBalls_is_in = false;
    private Vector3 previousPos;
    [SerializeField] private float fStrength = 10f;
    
    /*
     * Use fixedupdate to update the previous position of the ball
     * once the ball collides or enter a trigger:
     * use previous location and when we have entered into collision
     * make negative vector direction of current direction and add the cohesive force in that negative direction!
     * 
     */

    private void FixedUpdate()
    {
        // update the previous position only if it is not inside of collision
        if (!bBalls_is_in)
         previousPos = playerBall.position;
    }

    private void OnCollisionExit(Collision other)
    {
        bBalls_is_in = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        bBalls_is_in = true;
        if (other.gameObject.name == "PlayerBall")
        {
            Vector3 _newpos = playerBall.position - previousPos;
            Debug.Log("x:" + (-_newpos.x) + "y:" + (-_newpos.y) + "z:" + (-_newpos.z) );
            
            playerBall.AddForce(new Vector3(
                -_newpos.x * fStrength   , 
                -_newpos.y * fStrength   , 
                -_newpos.z * fStrength  ), 
                ForceMode.Impulse);
            
            
        }
    }
    
}

// Debug.Log("the name of the other gameobject is: " + other.gameObject.name);
// Debug.Log("Adding Force");
// other.rigidbody.AddForce(10f,0,0,ForceMode.Impulse);
            
//Overlap speed
            
            
            
// other.gameObject.transform.position;


//other.rigidbody.AddForce();
// Vector3 SoftForce()
// {
//     Vector3 _newDir;
//     
//
// }