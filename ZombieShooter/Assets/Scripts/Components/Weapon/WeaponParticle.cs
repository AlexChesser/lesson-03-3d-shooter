using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticle : WeaponComponent
{
    [SerializeField] private ParticleSystem particle;

    protected override void WeaponFired()
    {
        particle.Play();
    }
}
