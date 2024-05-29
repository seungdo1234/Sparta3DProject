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


    private void Start()
    {
        StartMove();
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
        int point = 0;
        transform.position = wayPoints[point++].position;
        
        while (true)
        {
            
            Vector3.MoveTowards(transform.position, wayPoints[point].position, speed * Time.deltaTime);
            yield return null;
        }
    }


}
