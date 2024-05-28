using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class InteractEventHandler : MonoBehaviour
{
    public float checkRate = 0.05f; // 얼마나 자주 레이를 쏠 것 인가 ?
    public float maxCheckDistance;
    public LayerMask layerMask;

    // 아이템 캐싱 관련 변수들
    public GameObject curInteractGameObject;
    private IInteractable curInteractable;
    public PromptUIHandler promptUIHandler;
    
    private Camera camera;

    private Coroutine searchCoroutine;
    private WaitForSeconds wait;

    private void Awake()
    {
        wait = new WaitForSeconds(checkRate);
    }

    private void Start()
    {
        camera = Camera.main;

        StartSearch();
    }

    private void StartSearch()
    {
        if (searchCoroutine != null)
        {
            StopCoroutine(searchCoroutine);
        }

        searchCoroutine = StartCoroutine(CheckForInteractables());
    }

    private IEnumerator CheckForInteractables()
    {
        while (true)
        {
            // ScreenToViewportPoint : 터치했을 때 기준
            // ScreenPointToRay : 카메라 기준으로 레이를 쏨
            // new Vector3(Screen.width / 2, Screen.height / 2) => 정 중앙에서 쏘기 위해
            // 카메라가 찍고 있는 방향이 기본적으로 앞을 바라보기 때문에 따로 방향 설정 X
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask)) // 충돌이 됐을 때
            {
                if (hit.collider.gameObject != curInteractGameObject) // 충돌한 오브젝트가 현재 상호작용하는 오브젝트가 아닐 때
                {
                    if (hit.collider.TryGetComponent(out IInteractable interactable))
                    {
                        curInteractGameObject = hit.collider.gameObject; // 오브젝트 변경
                        promptUIHandler.SetPrompt(interactable.GetInteractPrompt());
                    }
                    // curInteractGameObject = hit.collider.gameObject; // 오브젝트 변경
                    // curInteractable = hit.collider.GetComponent<IInteractable>();
                    // // // 프롬프트에 출력
                    // // SetPromptText();
                    // promptUIHandler.SetPrompt(curInteractable.GetInteractPrompt());
                }
            }
            else // 충돌한 오브젝트가 없다면 기존에 있던 정보들을 초기화
            {
                InteractionOff();
            }

            yield return wait;
        }
    }

    public void InteractionOff()
    {
        curInteractGameObject = null;
        promptUIHandler.DisablePrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context) // 상호작용
    {
        if (context.phase == InputActionPhase.Started && curInteractGameObject != null)
        {
            curInteractable.OnInteract();
            InteractionOff();
        }
    }
}