using UnityEngine;

public class ItemObject : MonoBehaviour , IInteractable
{
    public ObjectSO data;

    public string GetInteractPrompt()
    {
        string str = $"{data.displayName}\n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        // CharacterManager.Instance.Player.itemData = data;
        // CharacterManager.Instance.Player.adddItem?.Invoke();
        Destroy(gameObject);
    }
}
