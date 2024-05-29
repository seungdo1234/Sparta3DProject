public class StaminaPotionSlot : Slot
{
    public override void UseConsumableItem()
    {
        if (coolTimeUI.gameObject.activeSelf)
        {
            return;
        }
        
        base.UseConsumableItem();
        
        playerStatEventHandler.StaminaRecoveryEvent(conItemData.value);
    }
}