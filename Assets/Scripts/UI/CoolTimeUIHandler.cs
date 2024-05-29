using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoolTimeUIHandler : MonoBehaviour
{
    private Coroutine coolTimeCoroutine;
    private TextMeshProUGUI coolTimeText;
    private Image coolTimeImage;
    private void Awake()
    {
        coolTimeText = GetComponentInChildren<TextMeshProUGUI>();
        coolTimeImage = GetComponent<Image>();
        gameObject.SetActive(false);
    }


    public void SetCoolTime(float coolTime)
    {
        gameObject.SetActive(true);
        
        if (coolTimeCoroutine != null)
        {
            StopCoroutine(coolTimeCoroutine);
        }

        coolTimeCoroutine = StartCoroutine(StartCoolTimeCoroutine(coolTime));
    }

    private IEnumerator StartCoolTimeCoroutine(float coolTime)
    {
        float currentTime = 0f;
       
        while (currentTime < coolTime)
        {
            currentTime += Time.deltaTime;

            coolTimeText.text = (coolTime - Mathf.Floor(currentTime)).ToString();
            coolTimeImage.fillAmount = Mathf.Lerp(1f, 0f, currentTime / coolTime);
            
            yield return null;
        }
        
        gameObject.SetActive(false);
    }
    
        
    
    
}
