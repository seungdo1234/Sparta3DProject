using UnityEngine;

public class SpeedPotionSlot : Slot
{
    [SerializeField] private BuffUIHandler buffUIHandler;
    public override void UseConsumableItem()
    {
        if (coolTimeUI.gameObject.activeSelf)
        {
            return;
        }

        base.UseConsumableItem();
        buffUIHandler.SetBuffUI(conItemData.duration);
        playerStatEventHandler.SpeedUpEvent(conItemData.value, conItemData.duration);
    }
}