using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public HUD hudref;
    public Rigidbody playerball;

    private void OnTriggerExit(Collider other)
    {
        if (playerball)
        {
            hudref.TakeLife();
        }
    }
    
    
    
    
}
