using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWalkingState : PlayerState
{
    public PlayerWalkingState(PlayerStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        currentCharacterSpeed = 2f;
        stateMachine.Player.animator.SetFloat("speed", 0.5f);
    }

    public override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        base.OnWalkToggleStarted(context);

        stateMachine.ChangeState(stateMachine.RunningState);
    }
}