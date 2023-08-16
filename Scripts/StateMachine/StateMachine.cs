using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine
{
    protected IState currentState;

    public virtual void ChangeState(IState newState)
    {
        if(currentState == newState) return;

        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }

    public virtual void HandleInput()
    {
        currentState?.HandleInput();
    }

    public virtual void Update()
    {
        currentState?.Update();
    }

    public virtual void PhysicsUpdate()
    {
        currentState?.PhysicsUpdate();
    }
}