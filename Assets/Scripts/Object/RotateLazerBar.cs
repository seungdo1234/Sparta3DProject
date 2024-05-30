using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLazerBar : MonoBehaviour
{
   [SerializeField] private float rotSpeed;

   private void Update()
   {
      transform.Rotate(Vector3.right * (rotSpeed * Time.deltaTime));
   }
}
