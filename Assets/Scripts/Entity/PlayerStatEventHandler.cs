using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatEventHandler : MonoBehaviour
{

    private Coroutine delayCoroutine;
    public event Action OnHealthUpEvent;
    public event Action OnTakeDamageEvent;
    

    public void HealthRecoveryEvent(float amount)
    {
        Debug.Log("체력 회복 !");
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

    public void SpeedUpEvent(float value, float duration)
    {
        Debug.Log("스피드 업 !");
        GameManager.Instance.PlayerData.CurMoveSpeed += GameManager.Instance.PlayerData.BaseMoveSpeed * value;
        if (delayCoroutine != null)
        {
            StopCoroutine(delayCoroutine);
        }
        delayCoroutine = StartCoroutine(SpeedUpDuration(value, duration));
    }

    private IEnumerator SpeedUpDuration(float value , float duration)
    {

        yield return new WaitForSeconds(duration);
        Debug.Log("스피드 업 끝");
        GameManager.Instance.PlayerData.CurMoveSpeed -= GameManager.Instance.PlayerData.BaseMoveSpeed * value;
    }
    public void StaminaRecoveryEvent(float amount)
    {
        Debug.Log("스태미너 회복 !");
        GameManager.Instance.PlayerData.CurStamina = amount;
    }
}
