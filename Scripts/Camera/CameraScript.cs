using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    public Animator stateDrivenAnim { get; private set; }
    public PlayerInputActions InputActions { get; private set; }
    public PlayerInputActions.PlayerActions PlayerActions { get; private set; }

    bool lockCamera = false;

    private void OnEnable()
    {
        InputActions.Enable();
    }

    private void OnDisable()
    {
        InputActions.Disable();
    }

    private void Awake()
    {
        stateDrivenAnim = GetComponent<Animator>();

        InputActions = new PlayerInputActions();
        PlayerActions = InputActions.Player;

        PlayerActions.TargetLock.performed += onLock;
    }

    public void onLock(InputAction.CallbackContext context)
    {
        lockCamera = !lockCamera;

        if(!lockCamera)
        {
            stateDrivenAnim.Play("FollowCamera");
            Debug.Log("Follow Camera");
        }

        if (lockCamera)
        {
            stateDrivenAnim.Play("TargetCamera");
            Debug.Log("TargetCamera");
        }
    }
}
