using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnImpact : MonoBehaviour
{
    [SerializeField] PooledMonoBehaviour particles;

    private void OnCollisionEnter(Collision collision)
    {
        particles.Get<PooledMonoBehaviour>(transform.position, Quaternion.LookRotation(collision.contacts[0].normal));
    }
}
