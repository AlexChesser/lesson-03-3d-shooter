using System;
using System.Collections;
using UnityEngine;

public class PooledMonoBehaviour : MonoBehaviour
{
    [SerializeField] private int initialPoolSize = 5;
    public int InitialPoolSize => initialPoolSize;

    public event Action<PooledMonoBehaviour> OnReturnToPool;

    public T Get<T>(bool enable = true) where T : PooledMonoBehaviour {
        var pool = Pool.GetPool(this);
        var pooledObject = pool.Get<T>();
        if (enable) {
            pooledObject.gameObject.SetActive(true);
        }
        return pooledObject;
    }

    public T Get<T>(Vector3 position, Quaternion rotation) where T : PooledMonoBehaviour
    {
        var pooledObject = Get<T>();
        pooledObject.transform.position = position;
        pooledObject.transform.rotation = rotation;
        return pooledObject;
    }

    protected void OnDestroy()
    {
        //foreach (Delegate d in OnReturnToPool.GetInvocationList()) {
        //    OnReturnToPool -=  (Action<PooledMonoBehaviour>)d;
        //}
    }

    protected virtual void OnDisable()
    {
        OnReturnToPool?.Invoke(this);
    }

    protected void ReturnToPool(float delay = 0f)
    {
        StartCoroutine(ReturnToPoolAfterSeconds(delay));
    }

    private IEnumerator ReturnToPoolAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        gameObject.SetActive(false);
    }
}
