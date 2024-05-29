using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action<Vector2> onMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnJumpEvent;
    public event Action OnRunEvent;
    public event Action<int> OnUseEvent;
    public event Action OnPovEvent;

    protected void CallMoveEvent(Vector2 dir)
    {
        onMoveEvent?.Invoke(dir);;
    }
    protected void CallLookEvent(Vector2 delta)
    {
        OnLookEvent?.Invoke(delta);;
    }
    protected void CallJumpEvent()
    {
        OnJumpEvent?.Invoke();;
    }
    protected void CallRunEvent()
    {
        OnRunEvent?.Invoke();;
    }
    protected void CallUseEvent(int num)
    {
        OnUseEvent?.Invoke(num);
    }
    protected void CallPovEvent()
    {
        OnPovEvent?.Invoke();
    }
}
