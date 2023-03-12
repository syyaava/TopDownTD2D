using UnityEngine;

public class Resource : MonoBehaviour //TODO: Не нравится мне этот класс. Подумать как переделать
{
    public ResourceType Type;
    public string Name;
    public int Count;

    public enum ResourceType
    {
        Gold
    }

    public override string ToString()
    {
        return $"Resource: {Type}; Count: {Count}";
    }
}
