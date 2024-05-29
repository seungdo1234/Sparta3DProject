using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class HealthUIEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject takeDamageObject;
    [FormerlySerializedAs("healthSystem")] [SerializeField]private PlayerStatEventHandler playerStatEventHandler;
    private Image hpBar;

    private void Awake()
    {
        hpBar = transform.GetChild(0).GetComponent<Image>();
    }

    private void Start()
    {
        // healthSystem = GameManager.Instance.PlayerData.GetComponent<HealthSystem>();
        playerStatEventHandler.OnTakeDamageEvent += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        hpBar.fillAmount = GameManager.Instance.PlayerData.CurHealth / GameManager.Instance.PlayerData.MaxHealth;
        
        takeDamageObject.SetActive(false);
        takeDamageObject.SetActive(true);
    }
    
}
