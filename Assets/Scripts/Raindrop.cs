using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raindrop : MonoBehaviour
{
    public void OnCollisionEnter(Collision other)
    {
        
        
        Debug.Log("We hit something");
         
         
        /*If the other collision is the floor, increase the physics mat ground */
         
        //TODO GIVE BETTER NAME BLYAT
        if (other.gameObject.name == "floor" && other.gameObject != null)
        {
            //ok we hit the ground, now we increase this floor's physics material

            var otherGameObject = other.gameObject;
             
            otherGameObject.GetComponent<MeshCollider>().material.dynamicFriction += 1f;
            otherGameObject.GetComponent<MeshCollider>().material.staticFriction += 1f;

            // otherGameObject.GetComponent<PhysicMaterial>().dynamicFriction += 1f;
            // otherGameObject.GetComponent<PhysicMaterial>().staticFriction += 1f;


        }
         
         
         
    }

    
    
    
}///////////////////////////// end
