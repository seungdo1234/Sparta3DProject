using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUIHandler : MonoBehaviour
{
    private CoolTimeUIHandler coolTimeUIHandler;
    public GameObject panel;
    private void Awake()
    {
        coolTimeUIHandler = GetComponentInChildren<CoolTimeUIHandler>(true);
    }

    private void Start()
    {
        panel.SetActive(false);
    }

    public void SetBuffUI(float duration)
    {
        panel.gameObject.SetActive(true);
        coolTimeUIHandler.SetCoolTime(duration);
        Debug.Log(coolTimeUIHandler.gameObject.activeSelf);
        StartCoroutine(PanelDurationCoroutine(duration));
    }

    private IEnumerator PanelDurationCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        panel.gameObject.SetActive(false);
    }
}
