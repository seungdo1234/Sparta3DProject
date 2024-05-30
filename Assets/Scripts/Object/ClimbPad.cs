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

    private Movement PlayerMovement // 프로퍼티
    {
        get
        {
            if (PlayerMovement == null)
            {
                PlayerMovement = GameManager.Instance.PlayerData.GetComponent<Movement>();
            }

            return PlayerMovement;
        }
        set => PlayerMovement = value;
    } 

    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Player");
    }


    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(GameManager.Instance.IsLayerMatched(other.gameObject.layer, targetLayer.value));
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
