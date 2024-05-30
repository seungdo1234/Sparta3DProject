using System;
using System.Collections;
using UnityEngine;

public class ClimbPad : MonoBehaviour
{
    [SerializeField] private float climbDistance = 2f; // 플레이어와 ClimbPad 간의 등반 거리
    [SerializeField] private float detectDistance = 1f; // BoxCast 탐지 거리
    [SerializeField] private float climbSpeed = 3f; // 등반 속도
    private Coroutine climbCoroutine;
    private LayerMask targetLayer;

    private Movement playerMovement;
    private Movement PlayerMovement // 프로퍼티
    {
        get
        {
            if (playerMovement == null)
            {
                playerMovement = GameManager.Instance.PlayerData.GetComponent<Movement>();
            }

            return playerMovement;
        }
    } 

    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Player");
    }


    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value ,other.gameObject.layer) && other.contacts[0].normal.z == 1 )
        {
            PlayerMovement.WallClimb(true);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value ,other.gameObject.layer))
        {
            PlayerMovement.WallClimb(false);
        }
    }
}
