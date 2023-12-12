using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveState : IState
{
    private readonly TruckV2 _truckV2;
    public DriveState(TruckV2 truckV2)
    {
        _truckV2 = truckV2;
    }
    
    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("Entering DriveState");
    }

    public void Update()
    {
      
        // Breaking we enter transition to breakstate
        // if we are not moving we got to idlestate.
        
        
    }

    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("Exiting DriveState");
    }
}