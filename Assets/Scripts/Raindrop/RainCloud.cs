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
    public GameObject target;
    public Mesh mesh;
    public Vector3 minPos;
    public Vector3 maxPos;

    [SerializeField] private float TimeToDrop = 3f;
    [SerializeField] private float DropTimeCounter = 0;
    
    
    private void Start()
    {
        _rainPoolObject = GetComponent<RainPoolObject>();
    }

    private void FixedUpdate()
    {
        DropTimeCounter += Time.fixedDeltaTime; // adds 0.2 or something

        if (DropTimeCounter >= TimeToDrop)
        {
            SpawnDrop();
            DropTimeCounter = 0;
        }
        
        

    }


    private void MoveCloud()
    {
        // TODO: ADD Circular movement for the cloud to orbit.
        
        // transform.position = new Vector3()
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
            
            
            Debug.Log("RandPos is: " + obj.transform.position.ToString());


        }
        
        
    }
    
    
    
    
}
