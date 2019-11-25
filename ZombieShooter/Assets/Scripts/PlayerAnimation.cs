using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private float drawWeaponSpeed = 0.2f;
    private int idxShooting;

    private void Awake()
    {
        idxShooting = animator.GetLayerIndex("Shooting");
    }


    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            StartCoroutine(FadeToShootingLayer());
        } else if (Input.GetButtonUp("Fire1")) {
            StartCoroutine(FadeToShootingLayer(1));
        }
    }

    private IEnumerator FadeToShootingLayer(int reverse = 0)
    {
        float currentWeight = animator.GetLayerWeight(idxShooting);
        float elapsed = 0;
        while (elapsed < drawWeaponSpeed) {
            elapsed += Time.deltaTime;
            currentWeight = Math.Abs(reverse - elapsed / drawWeaponSpeed);
            animator.SetLayerWeight(idxShooting, currentWeight);
            yield return null;
        }
        animator.SetLayerWeight(idxShooting, 1 - reverse);
    }
}
