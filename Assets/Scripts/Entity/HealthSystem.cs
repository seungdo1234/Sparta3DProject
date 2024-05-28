using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public event Action OnHealthUpEvent;
    public event Action OnTakeDamageEvent;
    

    public void HealthEvent(float amount)
    {
        GameManager.Instance.PlayerData.CurHealth = amount;

        if (amount > 0)
        {
            OnHealthUpEvent?.Invoke();
        }
        else
        {
            OnTakeDamageEvent?.Invoke();
        }
    }
}
