using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInput : Singleton<PlayerInput>
{
    public event UnityAction<Vector2> onMove;
    public event UnityAction onAttack;

    PlayerInputAction playerInputAction;
    Vector2 axis => playerInputAction.GamePlay.Axis.ReadValue<Vector2>();
    public bool Jump => playerInputAction.GamePlay.Jump.WasPressedThisFrame();
    public bool StopJump => playerInputAction.GamePlay.Jump.WasReleasedThisFrame();
    public bool Move => AxisX != 0f;
    public bool IsDash => playerInputAction.GamePlay.Dash.WasPressedThisFrame();
    public bool IsSlide => playerInputAction.GamePlay.Slide.WasPressedThisFrame();
    public bool IsAttack => playerInputAction.GamePlay.Attack.WasPressedThisFrame();
    public float AxisX => axis.x;

    private void Awake()
    {
        playerInputAction = new PlayerInputAction();
    }

    public void EnableGamePlayInputs()
    {
        playerInputAction.GamePlay.Enable();
        Cursor.lockState = CursorLockMode.Locked;
    }
}
