using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 5;
    private int currentHealth;

    private void OnEnable()
    {
        currentHealth = health;
    }

    public void TakeHit(int amount) {
        currentHealth -= amount;
        GetComponentInChildren<Animator>().SetTrigger("Hit");
    }


}
