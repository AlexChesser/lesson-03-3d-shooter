using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedReturnToPool : PooledMonoBehaviour
{
    [SerializeField] private float delay = 1f;
    private void OnEnable()
    {
        ReturnToPool(delay);
    }

}
