using System;
using UnityEngine;

public class DeActiveObject : MonoBehaviour
{
    [SerializeField] private float time = 180;
    private void OnEnable()
    {
        time = 180f;
    }

    private void Update()
    {
        time--;
        if (time <= 0)
        {
            gameObject.SetActive(false);
        }
    }

}