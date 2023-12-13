using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using Random = UnityEngine.Random;

public class Cloud : MonoBehaviour
{
    public RainPoolObject _rainPoolObject;

    public Transform tf;
    public Transform parentTransform;
    public GameObject target;
    public Mesh mesh;
    public Vector3 minPos;
    public Vector3 maxPos;

    [SerializeField] private float TimeToDrop = 3f;
    [SerializeField] private float DropTimeCounter = 0;

    // This is for orbiting around
    public Transform centerPointOfRotation;
    
    public float rotSpeed = 3f;
    private bool _iscenterPointOfRotationNotNull;

    private void Start()
    {
        _iscenterPointOfRotationNotNull = centerPointOfRotation != null;
        _rainPoolObject = GetComponent<RainPoolObject>();
    }

    private void FixedUpdate()
    {
        DropTimeCounter += Time.fixedDeltaTime; // adds 0.2

        if (DropTimeCounter >= TimeToDrop)
        {
            SpawnDrop();
            DropTimeCounter = 0;
        }
        MoveCloud();
        

    }


    private void MoveCloud()
    {
        if (_iscenterPointOfRotationNotNull)
        {
            parentTransform.RotateAround(centerPointOfRotation.position, Vector3.up, rotSpeed * Time.fixedDeltaTime);
        }
    }
    

    private void SpawnDrop()
    {
        var obj = _rainPoolObject.GetPooledObject();
      
        if (target != null)
        {
            mesh = target.GetComponent<MeshFilter>().sharedMesh;

            Vector3 cloudScale = tf.localScale; // the scale of the transform tf
            Vector3 cloudExtends = cloudScale * 0.5f; //half of the scale 

            Vector3 boundPos = tf.position;

            boundPos += tf.TransformDirection(cloudScale * 0.5f);

            Vector3 randPos = new Vector3(
                Random.Range(-cloudExtends.x, cloudExtends.x),
                Random.Range(-cloudExtends.y, cloudExtends.y),
                Random.Range(-cloudExtends.z, cloudExtends.z)
            );

            Vector3 finalPos = boundPos + randPos;
            
            obj.transform.position = finalPos;
            // or 
             // obj.transform.Translate(randPos);
            
            // Dont need to debug
            // Debug.Log("RandPos is: " + obj.transform.position.ToString());


        }
        
        
    }
    
    
    
    
}
