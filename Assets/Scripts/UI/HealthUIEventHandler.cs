using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIEventHandler : MonoBehaviour
{
    [SerializeField] private GameObject takeDamageObject;
    [SerializeField]private HealthSystem healthSystem;
    private Image hpBar;

    private void Awake()
    {
        hpBar = transform.GetChild(0).GetComponent<Image>();
    }

    private void Start()
    {
        // healthSystem = GameManager.Instance.PlayerData.GetComponent<HealthSystem>();
        healthSystem.OnTakeDamageEvent += UpdateHealthUI;
    }

    private void UpdateHealthUI()
    {
        hpBar.fillAmount = GameManager.Instance.PlayerData.CurHealth / GameManager.Instance.PlayerData.MaxHealth;
        
        takeDamageObject.SetActive(false);
        takeDamageObject.SetActive(true);
    }
    
}
