using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePad : MonoBehaviour
{
    [Header("# MovePad")]
    [SerializeField] private Transform[] wayPoints;

    [SerializeField] private float speed;
    private Coroutine movePadCoroutine;
    private int point = 0;
    private readonly float threshold = 0.01f;
    
    private LayerMask targetLayer;

    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Player");
    }

    private void Start()
    {
        // 웨이포인트가 비어있는지 확인
        if (wayPoints.Length > 0)
        {
            // 첫 번째 웨이포인트로 초기 위치 설정
            transform.position = wayPoints[point++].position;
            StartMove();
        }
        else
        {
            Debug.LogWarning("웨이포인트가 설정되지 않았습니다.");
        }
    }

    private void StartMove()
    {
        if (movePadCoroutine != null)
        {
            StopCoroutine(movePadCoroutine);
        }

        movePadCoroutine = StartCoroutine(MovePadCoroutine());
    }

    private IEnumerator MovePadCoroutine()
    {
        while (true)
        {
            if (wayPoints.Length == 0) yield break;

            transform.position = Vector3.MoveTowards(transform.position, wayPoints[point].position, speed * Time.deltaTime);
            
            if (Vector3.Distance(transform.position, wayPoints[point].position) < threshold)
            {
                point = (point + 1) % wayPoints.Length;
            }

            yield return null;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value, other.gameObject.layer)&&  other.contacts[0].normal.y < 0)
        {
            // 플레이어를 플랫폼의 자식으로 설정
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value, other.gameObject.layer))
        {
            // 플레이어의 부모 관계 해제
            other.transform.SetParent(null);
        }
    }
}