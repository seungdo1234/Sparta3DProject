using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("# Jump")]
    [SerializeField] private LayerMask jumpCollisionLayers;
    private PlayerController controller;
    private Rigidbody rigid;
    private Vector2 curMoveDir;
    private bool isJumpping;
    private bool isRunning;
    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        controller.onMoveEvent += SetMoveEventDir;
        controller.OnJumpEvent += Jump;
        controller.OnRunEvent += Run;
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        // 앞뒤 + 좌우로 플레이어를 움직임
        Vector3 dir = transform.forward * curMoveDir.y + transform.right * curMoveDir.x;
        dir *= GameManager.Instance.PlayerData.CurMoveSpeed;
        // 점프를 했을 때만 위아래로 움직어여되기 때문에 미세한 값을 유지시키기위해 velocity.y를 넣음
        dir.y = rigid.velocity.y;
        rigid.velocity = dir;
    }

    private void SetMoveEventDir(Vector2 dir)
    {
        curMoveDir = dir;
    }

    private void Jump()
    {
        if (!isJumpping)
        {
            rigid.AddForce(Vector2.up * GameManager.Instance.PlayerData.JumpPower , ForceMode.Impulse);
            isJumpping = true;
        }
    }

    private void Run()
    {
        isRunning = !isRunning;
        float run = isRunning ? 1f : -1f;
        
        GameManager.Instance.PlayerData.CurMoveSpeed += GameManager.Instance.PlayerData.RunMoveSpeed * run;

    }
    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.Instance.IsLayerMatched(jumpCollisionLayers.value, other.gameObject.layer))
        {
            isJumpping = false;
        }
    }
}
