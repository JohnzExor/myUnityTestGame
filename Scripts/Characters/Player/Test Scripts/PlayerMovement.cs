using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public PlayerInputActions InputActions { get; private set; }
    public PlayerInputActions.PlayerActions PlayerActions { get; private set; }
    public CharacterController characterController { get; private set; }
    public Animator animator { get; private set; }

    private Camera cam;

    private Vector2 input;

    private float smoothTime = 0.1f;
    private float currentVelocity;

    private bool walkToggle = false;

    private int noOfClicks = 0;
    private bool canClick = true;
    private bool canAttack = false;

    private void Awake()
    {
        InputActions = new PlayerInputActions();
        PlayerActions = InputActions.Player;
        
        animator = GetComponentInChildren<Animator>(true);

        characterController = GetComponent<CharacterController>();

        cam = Camera.main;

        PlayerActions.Attack.performed += onClick;
        PlayerActions.Walk.performed += onWalkToggle;
    }

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    private void Update()
    {
        NormalHit();

        input = PlayerActions.Move.ReadValue<Vector2>();

        float currentSpeed = walkToggle ? 2f : 5f;
        float currentAnimSpeed = walkToggle ? 0.5f : 1f;

        if(input.magnitude > 0)
        {
            animator.SetFloat("speed", currentAnimSpeed);
        }

        if (input.magnitude == 0)
        {
            animator.SetFloat("speed", 0f);
            return;
        }

        Vector3 cameraForward = cam.transform.forward;
        cameraForward.y = 0f;
        cameraForward.Normalize();

        Vector3 moveDirection = cameraForward * input.y + cam.transform.right * input.x;

        var targetAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);
        transform.rotation = Quaternion.Euler(0f, angle, 0f);

        characterController.Move(moveDirection * Time.deltaTime * currentSpeed);
    }

    private void resetHit()
    {
        var currentState = animator.GetCurrentAnimatorStateInfo(0);

        if (currentState.normalizedTime > 0.8f)
        {
            if (currentState.IsName("Player_combat_hit1"))
            {
                animator.SetBool("hit1", false);
            }
            if (currentState.IsName("Player_combat_hit2"))
            {
                animator.SetBool("hit2", false);
            }
            if (currentState.IsName("Player_combat_hit3"))
            {
                animator.SetBool("hit3", false);
                noOfClicks = 0;
            }
            canClick = true;
            canAttack = false;
        }
    }

    private void NormalHit()
    {
        if (canAttack)
        {
            Vector3 forward = transform.forward;
            if (noOfClicks == 1)
            {
                characterController.Move(forward * Time.deltaTime);
                animator.SetBool("hit1", true);
            }
            if (noOfClicks == 2)
            {
                characterController.Move(forward * Time.deltaTime);
                animator.SetBool("hit2", true);
            }
            if (noOfClicks == 3)
            {
                characterController.Move(forward * Time.deltaTime * 5f);
                animator.SetBool("hit3", true);
            }

            canClick = false;
        }
        resetHit();
    }

    public void onClick(InputAction.CallbackContext context)
    {
        if (canClick)
        {
            noOfClicks++;
        }
        noOfClicks = Mathf.Clamp(noOfClicks, 0, 3);
        canAttack = true;
        HitDirection();
    }

    private void HitDirection()
    {
        Vector3 cameraFacing = cam.transform.forward;
        cameraFacing.y = 0f;
        cameraFacing.Normalize();

        transform.rotation = Quaternion.LookRotation(cameraFacing);
    }

    public void onWalkToggle(InputAction.CallbackContext context)
    {
        walkToggle = !walkToggle;
    }
}
