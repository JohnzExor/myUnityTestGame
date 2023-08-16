using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    public PlayerSO PlayerData;

    public PlayerInput input { get; private set; }
    public CharacterController controller { get; private set; }
    public Camera cam { get; private set; }
    public Animator animator { get; private set; }

    public PlayerStateMachine movementState { get; private set; }

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        controller = GetComponent<CharacterController>();
        cam = Camera.main;
        animator = GetComponentInChildren<Animator>(true);

        movementState = new PlayerStateMachine(this);
    }

    private void Start()
    {
        movementState.ChangeState(movementState.IdlingState);
    }

    private void Update()
    {
        movementState.HandleInput();
        movementState.Update();
    }

    private void FixedUpdate()
    {
        movementState.PhysicsUpdate();
    }
}