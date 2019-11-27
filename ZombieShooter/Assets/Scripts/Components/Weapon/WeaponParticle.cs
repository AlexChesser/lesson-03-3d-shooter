using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParticle : WeaponComponent
{
    [SerializeField] ParticleSystem particle;
    protected override void WeaponFired()
    {
        particle.Play();
    }
}
