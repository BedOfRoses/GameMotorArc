using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakState : IState
{
    private readonly TruckV2 _truckV2;
    public BreakState(TruckV2 truckV2)
    {
        _truckV2 = truckV2;
    }
    
    public void Enter()
    {
        Debug.Log("Entering BreakState");
    }

    public void Update()
    {
        
        // if we a
        
    }

    
  
    public void Exit()
    {
        Debug.Log("Exiting BreakState");    
    }
}
