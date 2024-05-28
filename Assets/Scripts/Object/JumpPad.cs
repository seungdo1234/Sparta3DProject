using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private LayerMask targetLayer;
    [Range(0f,15f)][SerializeField] private float jumpPadPower;
    
    private void OnCollisionEnter(Collision other)
    { 
        if (GameManager.Instance.IsLayerMatched(targetLayer.value, other.gameObject.layer) &&  other.contacts[0].normal.y < 0)
        {
            Rigidbody rigid = other.gameObject.GetComponent<Rigidbody>();
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector2.up * jumpPadPower, ForceMode.Impulse);
        }    
    }
}
