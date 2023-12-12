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
    
    
    private void Start()
    {
        _rainPoolObject = GetComponent<RainPoolObject>();

        
        if (target != null)
        {
            mesh = target.GetComponent<MeshFilter>().sharedMesh;

            var bounds = mesh.bounds;

            var position = target.transform.position;
            minPos = position - bounds.extents;
            maxPos = position + bounds.extents;

            Vector3 randPos = new Vector3(
                Random.Range(minPos.x,maxPos.x),
                Random.Range(minPos.y,maxPos.y),
                Random.Range(minPos.z,maxPos.z)
                
            );
            
            Debug.Log("RandPos is: " + randPos.ToString());


        }
        
        
  
        
    }

    private void FixedUpdate()
    {
            
        
    }


    private void SpawnDrop()
    {
        var obj = _rainPoolObject.GetPooledObject();
      
        if (target != null)
        {
            mesh = target.GetComponent<MeshFilter>().sharedMesh;

            var bounds = mesh.bounds;

            var position = target.transform.position;
            minPos = position - bounds.extents;
            maxPos = position + bounds.extents;

            Vector3 randPos = new Vector3(
                Random.Range(minPos.x,maxPos.x),
                Random.Range(minPos.y,maxPos.y),
                Random.Range(minPos.z,maxPos.z)
                
            );
            
            Debug.Log("RandPos is: " + randPos.ToString());


        }
        
        
    }
    
    
    
    
}
