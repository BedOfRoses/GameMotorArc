using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriveState : IState
{
    // private readonly PController _player;
    // public DriveState(PController player)
    // {
    //     _player = player;
    // }
    
    public void Enter()
    {
        // code that runs when we first enter the state
        Debug.Log("Entering DriveState");
    }

    public void Update()
    {
      
        
        
    }

    public void Exit()
    {
        // code that runs when we exit the state
        Debug.Log("Exiting DriveState");
    }
}
