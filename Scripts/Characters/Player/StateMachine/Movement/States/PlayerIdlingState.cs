using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdlingState : PlayerState
{
    public PlayerIdlingState(PlayerStateMachine playerMovementStateMachine) : base(playerMovementStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        currentCharacterSpeed = 0f;
        stateMachine.Player.animator.SetFloat("speed", 0f);
    }

    public override void Update()
    {
        base.Update();

        if(input.magnitude == 1 && walkToggle)
        {
            stateMachine.ChangeState(stateMachine.WalkingState);
        }

        if (input.magnitude == 1 && !walkToggle)
        {
            stateMachine.ChangeState(stateMachine.RunningState);
        }
    }
}
