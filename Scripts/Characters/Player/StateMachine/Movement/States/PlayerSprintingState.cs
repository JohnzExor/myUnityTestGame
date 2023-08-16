using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSprintingState : PlayerState
{
    public PlayerSprintingState(PlayerStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        currentCharacterSpeed = 6f;
        stateMachine.Player.animator.SetFloat("speed", 1.5f);
    }

    public override void OnPlayerSprintCanceled(InputAction.CallbackContext context)
    {
        base.OnPlayerSprintCanceled(context);

        stateMachine.ChangeState(stateMachine.RunningState);
    }
}
