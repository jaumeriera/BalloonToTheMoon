using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField, Tooltip("Throw exception when calling GetNext of an empty pool")]
    bool ThrowErrorOnEmpty = true;

    [SerializeField] int poolSize;
    [SerializeField] PoolableObject prefab;
    [SerializeField] List<PoolableObject> pool;

    void Awake()
    {
        pool = new List<PoolableObject>();

        for (int i = 0; i < poolSize; i++)
        {
            CreateElement();
        }

        Shuffle();
    }

    private PoolableObject CreateElement()
    {
        PoolableObject element = Instantiate(prefab);
        element.setPool(this);
        element.gameObject.SetActive(false);
        // pool.Add(element); // poolableObjects are added ondisable
        return element;
    }

    private void Shuffle()
    {
        List<PoolableObject> newPool = new List<PoolableObject>(pool.Count);
        List<int> newIndex = new List<int>(pool.Count);
        int idx;

        for (int i = 0; i < pool.Count; i++)
        {
            do
            {
                idx = UnityEngine.Random.Range(0, pool.Count);
            } while (newIndex.Contains(idx));
            newIndex.Add(idx);
            newPool.Add(pool[idx]);
        }
        pool = newPool;
    }

    public void addToPool(PoolableObject element)
    {
        pool.Add(element);
    }

    public PoolableObject GetNext()
    {
        #if UNITY_EDITOR
        CheckEmptyPoolException();
        #endif
        CheckEmptyPool();

        PoolableObject element = pool[0];
        pool.RemoveAt(0);
        return element;
    }

    private void CheckEmptyPoolException()
    {
        if (pool.Count == 0 && ThrowErrorOnEmpty)
        {
            throw new Exception("Calling GetNext on empty Pool");
        }
    }

    private void CheckEmptyPool()
    {
        if (pool.Count == 0)
        {
            CreateElement();
        }
    }
}