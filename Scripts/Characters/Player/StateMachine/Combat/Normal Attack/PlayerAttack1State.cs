using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack1State : PlayerState
{
    bool hitTurn;

    public PlayerAttack1State(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        hitTurn = true;
    }

    public override void Update()
    {
        base.Update();

        if(stateMachine.Player.animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.7f)
        {
            hitTurn = false;
        }

        stateMachine.Player.animator.SetBool("hit1", hitTurn);
    }
}
