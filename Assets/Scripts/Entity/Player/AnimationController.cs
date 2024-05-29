using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private readonly int isRunning = Animator.StringToHash("isRunning");
    private Animator anim;
    private PlayerController controller;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<PlayerController>();
    }

    private void Start()
    {
        controller.onMoveEvent += MoveAnimation;
    }

    private void MoveAnimation(Vector2 dir)
    {
        anim.SetBool(isRunning, dir != Vector2.zero);
    }
}
