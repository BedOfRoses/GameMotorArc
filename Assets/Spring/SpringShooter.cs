using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringShooter : MonoBehaviour
{

    public Rigidbody rb;
    public Transform rbTrans;
    [SerializeField] private float upwardsForce = 1000f;

    private void FixedUpdate()
    {
        var distance = Vector3.Distance(rbTrans.position, this.transform.position);
        // Debug.Log("Boy" + boy);
        if (Input.GetKey(KeyCode.Space) && distance <= 1.4f)
        {
            // Debug.Log("space");
            rb.AddForce(new Vector3(rb.position.x,rb.position.y*upwardsForce,rb.position.z),ForceMode.Impulse);
            // Debug.Log(new Vector3(rb.position.x,rb.position.y*upwardsForce,rb.position.z).ToString());
        }
    }
}
