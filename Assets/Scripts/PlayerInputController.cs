using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector2 curMovementInput;
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        // 앞뒤 + 좌우로 플레이어를 움직임
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= 5;
        // 점프를 했을 때만 위아래로 움직어여되기 때문에 미세한 값을 유지시키기위해 velocity.y를 넣음
        dir.y = rigid.velocity.y;
        rigid.velocity = dir;
    }


    public void OnMove(InputAction.CallbackContext context)
        {
            if (context.phase == InputActionPhase.Performed) // 키가 계속 눌리는 중
            {
                curMovementInput = context.ReadValue<Vector2>();
            }
            else if (context.phase == InputActionPhase.Canceled)
            {
                curMovementInput = Vector2.zero;
            }
        }
}
