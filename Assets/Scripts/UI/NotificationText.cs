using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using TMPro;
using UnityEngine;

public class NotificationText : MonoBehaviour
{
    private TextMeshProUGUI notiText;
    private Coroutine countDownCoroutine;
    
    private void Awake()
    {
        notiText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetCountText(float timer)
    {
        if (countDownCoroutine != null)
        {
            StopCoroutine(countDownCoroutine);
        }

        notiText.gameObject.SetActive(true);
        countDownCoroutine = StartCoroutine(CountDownCoroutine(timer));
    }

    public void DisableCountText()
    {
        StopCoroutine(countDownCoroutine);
        notiText.gameObject.SetActive(false);
    }
    private IEnumerator CountDownCoroutine(float timer)
    {
        while (timer > 0)
        {
            notiText.text = timer.ToString("F2");
            timer -= Time.deltaTime;
            
            yield return null;
        }
        
        notiText.gameObject.SetActive(false);
    }

}
