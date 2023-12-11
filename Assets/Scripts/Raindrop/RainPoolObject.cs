using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainPoolObject : MonoBehaviour
{

    [SerializeField] private uint initPSize;
    [SerializeField] private PooledObject objToPool;

    private Stack<PooledObject> stack;


    private void Start()
    {
        RunPoolSetup();
    }


    private void RunPoolSetup()
    {
        // Create new pool stack-instance
        stack = new Stack<PooledObject>();

        PooledObject inst = null;

        for (int i = 0; i < initPSize; i++)
        {
            inst = Instantiate(objToPool);
            inst.Pool = this;
            // Start with the object being hidden.
            inst.gameObject.SetActive(false);
            stack.Push(inst);
            
        }

    }

    public PooledObject GetPooledObject()
    {
        // if empty create a new instance
        if (stack.Count == 0)
        {
            PooledObject newInst = Instantiate(objToPool);
            newInst.Pool = this;
            return newInst;
        }
        // Get the next one
        PooledObject nextInst = stack.Pop();
        nextInst.gameObject.SetActive(true);
        return nextInst;
    }
    
    public void ReturnToPool(PooledObject pObj)
    {
        stack.Push(pObj);
        pObj.gameObject.SetActive(false);
    }
    
    
    
    
}
