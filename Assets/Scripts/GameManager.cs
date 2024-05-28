using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    
    public PlayerData PlayerData { get; set; }
    
    public bool IsLayerMatched(int layerMask, int objectLayer)
    {
        return layerMask == (layerMask | (1 << objectLayer));
    }
}
