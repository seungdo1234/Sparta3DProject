using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] protected ConsumableItemSo conItemData;
    [SerializeField] protected CoolTimeUIHandler coolTimeUI;
    protected PlayerStatEventHandler playerStatEventHandler;

    public virtual void UseConsumableItem()
    {
        if (playerStatEventHandler == null)
        {
            playerStatEventHandler = GameManager.Instance.PlayerData.GetComponent<PlayerStatEventHandler>();
        }
        
        coolTimeUI.SetCoolTime(conItemData.coolTime);
    }
    
}