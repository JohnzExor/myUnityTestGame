using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : IState
{
    public PlayerStateMachine stateMachine { get; private set; }

    protected Vector2 input;
    protected Vector3 moveDirection;

    float smoothTime = 0.1f;
    float currentVelocity;

    public float currentCharacterSpeed;
    public float currentAnimationSpeed;

    public bool walkToggle = false;
    public bool isPlayerSprint = false;

    public bool isDashing = false;

    public PlayerState(PlayerStateMachine playerStateMachine)
    {
        stateMachine = playerStateMachine;
    }

    public virtual void Enter()
    {
        Debug.Log("State: " + GetType().Name);

        AddInputActionsCallbacks();
    }

    public virtual void Exit()
    {
        RemoveInputActionsCallbacks();
    }

    public void HandleInput()
    {
        ReadPlayerInput();
    }

    public void PhysicsUpdate()
    {
    }

    public virtual void Update()
    {
        stateMachine.Player.controller.Move(moveDirection * Time.deltaTime * currentCharacterSpeed);
        CurrentState();
    }

    public void ReadPlayerInput()
    {
        input = stateMachine.Player.input.InputActions.Player.Move.ReadValue<Vector2>();

        if (input.magnitude == 0)
        {
            return;
        }

        Vector3 cameraForward = stateMachine.Player.cam.transform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        moveDirection = cameraForward * input.y + stateMachine.Player.cam.transform.right * input.x;

        var targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(stateMachine.Player.transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        stateMachine.Player.transform.rotation = Quaternion.Euler(0, angle, 0);
    }

    public void CurrentState()
    {
        if (input.magnitude == 0 && !isDashing)
        {
            stateMachine.ChangeState(stateMachine.IdlingState);
        }
    }

    protected virtual void AddInputActionsCallbacks()
    {
        stateMachine.Player.input.InputActions.Player.Walk.started += OnWalkToggleStarted;
        stateMachine.Player.input.InputActions.Player.Sprint.started += OnPlayerSprintStarted;
        stateMachine.Player.input.InputActions.Player.Sprint.canceled += OnPlayerSprintCanceled;

        stateMachine.Player.input.InputActions.Player.Attack.started += OnPlayerNormalAttackStarted;
    }

    protected virtual void RemoveInputActionsCallbacks()
    {
        stateMachine.Player.input.InputActions.Player.Walk.started -= OnWalkToggleStarted;
    }

    public virtual void OnPlayerSprintStarted(InputAction.CallbackContext context)
    {
        isPlayerSprint = true;
    }

    public virtual void OnPlayerSprintCanceled(InputAction.CallbackContext context)
    {
        isPlayerSprint = false;
    }

    public virtual void OnWalkToggleStarted(InputAction.CallbackContext context)
    {
        walkToggle = !walkToggle;
    }

    public virtual void OnPlayerNormalAttackStarted(InputAction.CallbackContext context)
    {
        stateMachine.ChangeState(stateMachine.Attack1State);
    }
}