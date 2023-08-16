using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{
    public Player Player { get; }

    //Moving States
    public PlayerDashingState DashingState { get; }
    public PlayerIdlingState IdlingState { get; }
    public PlayerWalkingState WalkingState { get; }
    public PlayerRunningState RunningState { get; }
    public PlayerSprintingState SprintingState { get; }


    //Player Normal Attack State
    public PlayerAttack1State Attack1State { get; }
    public PlayerAttack2State Attack2State { get; }
    public PlayerAttack3State Attack3State { get; }

    public PlayerStateMachine(Player player)
    {
        Player = player;

        DashingState = new PlayerDashingState(this);
        IdlingState = new PlayerIdlingState(this);
        WalkingState = new PlayerWalkingState(this);
        RunningState = new PlayerRunningState(this);
        SprintingState = new PlayerSprintingState(this);

        Attack1State = new PlayerAttack1State(this);
        Attack2State = new PlayerAttack2State(this);
        Attack3State = new PlayerAttack3State(this);
    }
}