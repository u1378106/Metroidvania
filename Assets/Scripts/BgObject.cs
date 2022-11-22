using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BgObject : MonoBehaviour
{

    private IObjectPool<BgObject> objectPool;

    public void SetPool(IObjectPool<BgObject> pool)
    {
        objectPool = pool;
    }

    void OnCollisionEnter(Collision col)
    {
        objectPool.Release(this);
    }
}