using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRunningState : PlayerState
{
    public PlayerRunningState(PlayerStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        currentCharacterSpeed = 4f;
        stateMachine.Player.animator.SetFloat("speed", 1f);
    }

    public override void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        base.OnWalkToggleStarted(context);

        stateMachine.ChangeState(stateMachine.WalkingState);
    }

    public override void OnPlayerSprintStarted(InputAction.CallbackContext context)
    {
        base.OnPlayerSprintStarted(context);

        stateMachine.ChangeState(stateMachine.DashingState);
    }
}
