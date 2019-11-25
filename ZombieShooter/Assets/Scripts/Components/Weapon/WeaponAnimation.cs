using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class WeaponAnimation : WeaponComponent
{
    private Animator animator;
    private int kFire;

    private void Start()
    {
        animator = GetComponent<Animator>();
        kFire = Animator.StringToHash("Fire");
    }

    protected override void WeaponFired()
    {
        animator.SetTrigger(kFire);
    }


}
