using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{
    public BgObject prefab;
    private IObjectPool<BgObject> objectPool;

    void Start()
    {
        objectPool = new ObjectPool<BgObject>(InstantiateObject, OnObject, OnReleased);
    }

    private BgObject InstantiateObject()
    {
        BgObject obj = Instantiate(prefab);
        obj.SetPool(objectPool);
        return obj;
    }

    public void OnObject(BgObject obj)
    {
        obj.gameObject.SetActive(true);
    }

    public void OnReleased(BgObject obj)
    {
        obj.gameObject.SetActive(false);
    }

    void Update()
    {
        objectPool.Get();
        //Instantiate(prefab);
    }
}