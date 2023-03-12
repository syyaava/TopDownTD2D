using System;
using UnityEngine;


[System.Serializable]
public class Resource 
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
