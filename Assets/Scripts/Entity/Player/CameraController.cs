using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private PlayerController controller;
    private GameObject onePovCam;
    private GameObject threePovCam;
    private bool isOnePov = true;
    private void Awake()
    {
        controller = transform.root.GetComponent<PlayerController>();
        onePovCam = transform.GetChild(0).gameObject;
        threePovCam = transform.GetChild(1).gameObject;
    }

    private void Start()
    {
        controller.OnPovEvent += ConvertCam;
    }

    private void ConvertCam()
    {
        isOnePov = !isOnePov;
        
        onePovCam.gameObject.SetActive(isOnePov);
        threePovCam.gameObject.SetActive(!isOnePov);
    }
}

