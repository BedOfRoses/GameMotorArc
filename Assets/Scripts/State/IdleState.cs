using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    private readonly TruckV2 _truckV2;
    public IdleState(TruckV2 truckV2)
    {
        _truckV2 = truckV2;
    }
    
    public void Enter()
    {
        Debug.Log("Entering IdleState");
    }

    public void Update()
    {
        // When we are beginning to move
        // or
        // When we are braking
    }
    
    public void Exit()
    {
        Debug.Log("Exiting IdleState");
    }
}
