using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] public class TruckStateMachine
{
    public IState CurrentState { get; private set; }
    public IdleState _idleState;
    public BreakState _breakState;
    public DriveState _driveState;

    public TruckStateMachine(TruckV2 truck)
    {
        _driveState = new DriveState(truck);
        _idleState = new IdleState(truck);
        _breakState = new BreakState(truck);
    }

    public void Initialize(IState startingState)
    {
        CurrentState = startingState;
        startingState.Enter();
    }

    public void TransitionTo(IState nextState)
    {
        CurrentState.Exit(); // Leave the current state
        CurrentState = nextState; // Set the current state to the next one
        nextState.Enter(); // Enter new state
    }

    public void Update()
    {
        CurrentState?.Update();
    }
    
}
