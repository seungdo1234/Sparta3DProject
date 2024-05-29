public class HealingPotionSlot : Slot
{
    public override void UseConsumableItem()
    {
        if (coolTimeUI.gameObject.activeSelf)
        {
            return;
        }
        
        base.UseConsumableItem();
        
        playerStatEventHandler.HealthRecoveryEvent(conItemData.value);
    }
}