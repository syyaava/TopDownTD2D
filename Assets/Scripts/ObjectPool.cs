using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Transform SpawnedObjectsParent;

    [SerializeField]
    protected GameObject ObjectToPool;
    [SerializeField]
    protected int size = 10;
    protected Queue<GameObject> pool;

    protected void Awake()
    {
        pool = new Queue<GameObject>();
    }

    public void Initialize(GameObject objectToPool, int poolSize = 10)
    {
        ObjectToPool = objectToPool;
        size = poolSize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spawnedObject;
        if (pool.Count < size)
        {
            spawnedObject = Instantiate(ObjectToPool, transform.position, Quaternion.identity);
            spawnedObject.name = transform.root.name + "_" + ObjectToPool.name + "_" + pool.Count;
            spawnedObject.transform.SetParent(SpawnedObjectsParent);
            spawnedObject.AddComponent<DestroyIfDisabled>();
        }
        else
        {
            spawnedObject = pool.Dequeue();
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }    

        pool.Enqueue(spawnedObject);
        return spawnedObject;
    }

    protected void CreateObjectParentIfNeeded()
    {
        if(SpawnedObjectsParent == null)
        {
            var name = "ObjectPool_" + ObjectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
                SpawnedObjectsParent = parentObject.transform;
            else
                SpawnedObjectsParent = new GameObject(name).transform;
        }
    }

    private void OnDestroy()
    {
        foreach(var item in pool)
        {
            if (item == null)
                continue;
            else if (item.activeSelf == false)
                Destroy(item);
            else
                item.GetComponent<DestroyIfDisabled>().SelfDestructionEnabled = true;
        }
    }
}
