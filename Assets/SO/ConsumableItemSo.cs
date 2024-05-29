using UnityEngine;

[CreateAssetMenu(menuName = "ConItemSO", fileName = "ConItemSO")]
public class ConsumableItemSo : ObjectSO
{
    [Header("# Consumable")]
    public float value;
    public float coolTime;
    
    [Header("# Status")]
    public float duration;
}