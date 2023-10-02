using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringShooter : MonoBehaviour
{

    public Rigidbody rb;
    public Transform rbTrans;
    [SerializeField] private float upwardsForce = 50;
    
    [SerializeField] Vector3 OffsetPosition = Vector3.zero;
    
    [SerializeField] Vector3 StartPositon = Vector3.zero;
    private float t_val = 0;

    private void Awake()
    {
        StartPositon = transform.position;
    }

    private void FixedUpdate()
    {
        var distance = Vector3.Distance(rbTrans.position, this.transform.position);
        t_val = 0;
        
        if (Input.GetKey(KeyCode.Space) && distance <= 1.4f)
        {
            t_val = 1;
            rb.AddForce(0,upwardsForce,0,ForceMode.Impulse);
        }
        transform.position = Vector3.Lerp(StartPositon, OffsetPosition, Time.fixedDeltaTime * t_val);

    }
}
