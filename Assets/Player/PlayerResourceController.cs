using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerResourceController : MonoBehaviour
{
    public static List<Resource> Resources = new List<Resource>();

    void Start()
    {
        var resources = Enum.GetValues(typeof(Resource.ResourceType)).Cast<Resource.ResourceType>();
        foreach (var resource in resources)
        {
            Resources.Add(new Resource()
            {
                Type = resource,
                Name = resource.ToString(),
                Count = 10,
            });
        }
    }

    public void AddResources(params Resource[] resources)
    {
        foreach (var resource in resources)
        {
            var res = Resources.FirstOrDefault(x => x.Type == resource.Type);
            if(res != null)
                res.Count += resource.Count;
        }
    }

    public void RemoveResources(params Resource[] resources)
    {
        foreach (var resource in resources)
        {
            var res = Resources.FirstOrDefault(x => x.Type == resource.Type);
            if (res != null)
            {
                res.Count -= resource.Count;
                if(res.Count < 0)
                    res.Count = 0;
            }
        }
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
