
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UsableItemSlot : MonoBehaviour
{
    [SerializeField] private Slot[] slots;
    [SerializeField] private PlayerController controller;
    private PlayerStatEventHandler playerStatEventHandler;

    private void Awake()
    {
        playerStatEventHandler = controller.GetComponent<PlayerStatEventHandler>();
    }

    private void Start()
    {
        slots = GetComponentsInChildren<Slot>();
        
        controller.OnUseEvent += UseItem;
    }

    private void UseItem(int num)
    {
        slots[num - 1].UseConsumableItem();
    }
}