using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckV2 : MonoBehaviour
{

    [SerializeField] private List<GameObject> WheelPrefabs;
    [SerializeField] private float maxSus;
    [SerializeField] private float susMulti;
    [SerializeField] private float dampSens;
    [SerializeField] private float maxDamper;
    [SerializeField] private Rigidbody rb;


    private void Awake()
    {
        foreach (var wheel in WheelPrefabs)
        {
                
            
        }
        
    }
}
