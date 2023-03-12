using System;
using UnityEngine;

//[CreateAssetMenu(fileName = "NewResource", menuName = "Data/Resource/Resource")]
[Serializable]
public class Resource //: ScriptableObject //TODO: Не нравится мне этот класс. Подумать как переделать
{
    public ResourceType Type;
    public int Count = 1;

    public override string ToString()
    {
        return $"Resource: {Type}; Count: {Count}";
    }

    public enum ResourceType
    {
        Gold
    }
}
