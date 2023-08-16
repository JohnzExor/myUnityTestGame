using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack3State : PlayerState
{
    public PlayerAttack3State(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        stateMachine.Player.animator.SetBool("hit1", true);
    }
}
