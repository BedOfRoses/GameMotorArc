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
        if (_truckV2.IsBreaking)
            _truckV2.truckStateMachine.TransitionTo(_truckV2.truckStateMachine._breakState);
        
        if(_truckV2.IsMoving)
            _truckV2.truckStateMachine.TransitionTo(_truckV2.truckStateMachine._driveState);
    }
    
    public void Exit()
    {
        Debug.Log("Exiting IdleState");
    }
}
