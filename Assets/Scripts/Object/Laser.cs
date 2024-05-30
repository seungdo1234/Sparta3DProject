using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[System.Serializable]
public class LaserData
{
    public Transform point;
    public bool isRight;
}
public class Laser : MonoBehaviour
{
    [Header("# Laser")]
    [SerializeField] private LaserData[] laserDatas; // 레이저 포인터의 위치 정보 
    [SerializeField] private float distance = 100f; // 레이저의 발사 범위 
    [SerializeField] private LayerMask targetLayer; // 감지할 레이어
    [SerializeField] private float detectRadius = 1f; // 원형 레이캐스트 반경
    [SerializeField] private float damage = 10;

    [Header("# Warning")]
    [SerializeField] private GameObject warningGameObject;
    
    private Coroutine laserCoroutine;
    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Player");
    }

    private void Start()
    {
        StartLaser();
    }

    private void StartLaser()
    {
        if (laserCoroutine != null)
        {
            StopCoroutine(laserCoroutine);
        }
        laserCoroutine = StartCoroutine(LaserCoroutine());
    }

    private IEnumerator LaserCoroutine()
    {
        while (true)
        {
            foreach (LaserData laserPoint in laserDatas)
            {
                DetectPlayer(laserPoint);
            }
            yield return null;
        }
    }

    private void DetectPlayer(LaserData laserPoint)
    {
        float sphereScale = Mathf.Max(laserPoint.point.lossyScale.x, laserPoint.point.lossyScale.y, laserPoint.point.lossyScale.z);
        Vector3 vec = laserPoint.isRight ? laserPoint.point.right : -laserPoint.point.right;
        
        if (Physics.SphereCast(laserPoint.point.position, sphereScale / 2.0f, vec, out RaycastHit hit, distance , targetLayer))
        {
            Debug.Log("레이저 감지...");
            if (!warningGameObject.activeSelf)
            {
                warningGameObject.SetActive(true);   
            }
        }
    }

    
}