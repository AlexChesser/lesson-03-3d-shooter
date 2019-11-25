using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticle : WeaponComponent
{
    [SerializeField] private PooledMonoBehaviour particle;

    protected override void WeaponFired()
    {
        particle.Get<PooledMonoBehaviour>(weapon.BarrelEnd.position, weapon.BarrelEnd.rotation);
    }
}
