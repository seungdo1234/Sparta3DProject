using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ObjectSO", fileName = "ObjectSO")]
public class ObjectSO : ScriptableObject
{
    [Header("# Info")] 
    public string displayName; // 아이템 이름
    public string description; // 아이템 설명
}
