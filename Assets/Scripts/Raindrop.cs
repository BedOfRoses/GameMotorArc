using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Raindrop : MonoBehaviour
{
    /// <summary>
    /// Currently this is only spawning and setting the material friction higher,
    /// however it should decrease so imma change that rn
    /// </summary>
    /// <param name="other"></param>
    public void OnCollisionEnter(Collision other)
    {
        /*If the other collision is the floor, decrease the physics mat ground */
        if (other.gameObject.name == "floor")
        {
            //ok we hit the ground, now we increase this floor's physics material
            var otherGameObject = other.gameObject;
            
            //TODO, REVISIT AND CREATE BETTER LOGIC THAT DOESNT GO INFINITIVELY LOWER AND LOWER VALUE FOR SLIPPERYNESS
            // otherGameObject.GetComponent<MeshCollider>().material.dynamicFriction -= 0.000001f;
            // otherGameObject.GetComponent<MeshCollider>().material.staticFriction -= 0.000001f;
        }
        
        Destroy(this);
        
    }
}///////////////////////////// end
