using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashingState : PlayerState
{
    Vector3 dashForward;
    float dashDuration;

    public PlayerDashingState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        isDashing = true;

        dashDuration = 0.6f;
        stateMachine.Player.animator.SetTrigger("playerDash");

        dashForward = stateMachine.Player.transform.forward;
    }

    public override void Update()
    {
        base.Update();

        dashDuration -= Time.deltaTime;

        stateMachine.Player.controller.Move(dashForward * Time.deltaTime * 10f);

        if(dashDuration <= 0f)
        {
            isDashing = false;
            if(!isPlayerSprint)
            {
                stateMachine.ChangeState(stateMachine.RunningState);
            }

            if (isPlayerSprint)
            {
                stateMachine.ChangeState(stateMachine.SprintingState);
            }
        }
    }
}
