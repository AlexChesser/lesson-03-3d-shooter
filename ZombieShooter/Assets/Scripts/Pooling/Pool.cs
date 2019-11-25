using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private static Dictionary<PooledMonoBehaviour, Pool> pools = new Dictionary<PooledMonoBehaviour, Pool>();

    public static Pool GetPool(PooledMonoBehaviour prefab) {
        if (pools.ContainsKey(prefab)) {
            return pools[prefab];
        }
        var pooledGameObject = new GameObject($"Pool-{prefab.name}");
        var pool = pooledGameObject.AddComponent<Pool>();
        pool.prefab = prefab;
        pools.Add(prefab, pool);
        return pool;
    }

    private PooledMonoBehaviour prefab;
    private Queue<PooledMonoBehaviour> objects = new Queue<PooledMonoBehaviour>();
    public T Get<T>() where T : PooledMonoBehaviour {
        if (objects.Count == 0) {
            GrowPool();
        }
        var pooledObject = objects.Dequeue();
        return pooledObject as T;
    }

    private void GrowPool()
    {
        for (int i = 0; i < prefab.InitialPoolSize; i++) {
            var pooledObject = Instantiate(prefab) as PooledMonoBehaviour;
            pooledObject.gameObject.name += " " + i;
            pooledObject.OnReturnToPool += AddObjectToAvailableQueue;
            pooledObject.transform.SetParent(transform);
            pooledObject.gameObject.SetActive(false);
            objects.Enqueue(pooledObject);
        }
    }

    private void AddObjectToAvailableQueue(PooledMonoBehaviour pooledObject)
    {
        pooledObject.transform.SetParent(transform);
        objects.Enqueue(pooledObject);
    }
}
