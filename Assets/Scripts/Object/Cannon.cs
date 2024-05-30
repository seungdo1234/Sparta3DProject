using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private NotificationText notificationText;
    [SerializeField] private float time = 3f;
    [SerializeField] private float Power = 50f;
    private LayerMask targetLayer;
    private Coroutine fireCannonCoroutine;
    private WaitForSeconds wait;
    private Rigidbody playerRigid;
    private void Awake()
    {
        targetLayer = LayerMask.GetMask("Player");
        wait = new WaitForSeconds(time);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value, other.gameObject.layer))
        {
            notificationText.SetCountText(time);

            if (fireCannonCoroutine != null)
            {
                StopCoroutine(fireCannonCoroutine);
            }
            fireCannonCoroutine = StartCoroutine(FireCannonCoroutine());
        }
    }

    private IEnumerator FireCannonCoroutine()
    {
        yield return wait;

        if (playerRigid == null)
        {
            playerRigid = GameManager.Instance.PlayerData.GetComponent<Rigidbody>();
        }
        
        playerRigid.AddForce(Vector3.up * Power, ForceMode.Impulse);
    }

private void OnTriggerExit(Collider other)
    {
        if (GameManager.Instance.IsLayerMatched(targetLayer.value, other.gameObject.layer))
        {
            notificationText.DisableCountText();
            
            if (fireCannonCoroutine != null)
            {
                StopCoroutine(fireCannonCoroutine);
                fireCannonCoroutine = null;
            }   
        }
    }
}
