using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerController
{
    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed) // 키가 계속 눌리는 중
        {
            CallMoveEvent(context.ReadValue<Vector2>());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            CallMoveEvent(Vector2.zero);
        }
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        CallLookEvent(context.ReadValue<Vector2>());
    }
    
    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CallJumpEvent();
        }
        
    }
    
    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started || context.phase == InputActionPhase.Canceled)
        {
            CallRunEvent();
        }
    }
    
    public void OnUse(InputAction.CallbackContext context)
    {
        if (int.TryParse(context.control.displayName, out int num))
        {
            CallUseEvent(num);
        }
    }
    public void OnPOV(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            CallPOVEvent();
        }
    }
}