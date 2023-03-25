using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerResourceController : MonoBehaviour
{
    public static PlayerResourceController Instance { get; private set; }

    public List<Resource> Resources = new List<Resource>();
    public int StartResourcesCount = 10;
    public static long FragsCount = 0;

    private void Awake()
    {
        Instance = this;
        FragsCount = 0;
    }

    void Start()
    {
        var resources = Enum.GetValues(typeof(Resource.ResourceType)).Cast<Resource.ResourceType>();
        foreach (var resource in resources)
        {
            Resources.Add(new Resource()
            {
                Type = resource,
                Count = StartResourcesCount,
            });
        }
    }

    public void AddResources(params Resource[] resources)
    {
        if(resources == null || resources.Length == 0)
            return;

        foreach (var resource in resources)
        {
            var res = Resources.FirstOrDefault(x => x.Type == resource.Type);
            if(res != null)
                res.Count += resource.Count;
        }

        var str = string.Join<Resource>(" ", resources);
        PGFLogger.Log($"Resources: {str} were added.");
    }

    public bool RemoveResources(params Resource[] resources)
    {
        if (resources == null || resources.Length == 0)
            return false;

        var haveResources = HaveResources(resources);
        if(!haveResources) return false;

        foreach (var resource in resources)
        {
            var res = Resources.FirstOrDefault(x => x.Type == resource.Type);
            if (res != null)
            {
                res.Count -= resource.Count;
                if (res.Count < 0)
                    res.Count = 0;
            }
        }

        var str = string.Join<Resource>(" ", resources);
        PGFLogger.Log($"Resources: {str} were removed.");
        return true;
    }

    public bool HaveResource(Resource resource)
    {
        var res = Resources.FirstOrDefault(x => x.Type == resource.Type);
        return res.Count >= resource.Count;
    }

    public bool HaveResources(params Resource[] resources)
    {
        foreach(var res in resources)
            if(!HaveResource(res))
                return false;
        return true;
    }
}
