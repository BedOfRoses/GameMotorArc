using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledObject : MonoBehaviour
{

    private RainPoolObject pool;
    public RainPoolObject Pool
    {
        get => pool;
        set => pool = value;
    }

    public void Release()
    {
        pool.ReturnToPool(this);
    }
    
    
}
