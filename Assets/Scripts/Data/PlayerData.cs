using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [Header("# Player Stats")]
    [SerializeField] private float maxHealth;
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float runMoveSpeed;
    [SerializeField] private float jumpPower;
    [SerializeField] private float maxStamina;
    [SerializeField] private float curStamina;

    private float curHealth;
    private float curMoveSpeed;
    
    public float CurMoveSpeed
    {
        get { return curMoveSpeed;}
        set => curMoveSpeed = value;
    }
    public float CurHealth
    {
        get { return curHealth;}
        set
        {
            curHealth += value;
            if (curHealth > maxHealth)
            {
                curHealth = maxHealth;
            }

            if (curHealth <= 0)
            {
                curHealth = 0;
                Dead();
            }
        } 
    }
    public float CurStamina
    {
        get { return curStamina;}
        set
        {
            curStamina += value;
            if (curStamina > maxStamina)
            {
                curStamina = maxStamina;
            }

            if (curStamina <= 0)
            {
                curStamina = 0;
            }
        } 
    }
    public float BaseMoveSpeed => baseMoveSpeed;
    public float RunMoveSpeed => runMoveSpeed;
    public float JumpPower => jumpPower;
    public float MaxHealth => maxHealth;
    public float MaxStamina => maxStamina;
    
    private void Awake()
    {
        curMoveSpeed = baseMoveSpeed;
        curHealth = maxHealth;
    }

    private void Start()
    {
        GameManager.Instance.PlayerData = this;
    }

    private void Dead()
    {
        
    }
}
