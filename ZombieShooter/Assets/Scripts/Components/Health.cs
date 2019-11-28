using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 5;
    private int currentHealth;

    public event Action OnTookHit = delegate { };
    public event Action OnDied = delegate { };
    public event Action<int, int> OnHealthChanged = delegate { };

    private void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public void ModifyHealth(int amount) {
        currentHealth += amount;
        OnHealthChanged(currentHealth, maxHealth);
    }

    public void TakeHit(int amount) {
        if (currentHealth <= 0) {
            return;
        }
        ModifyHealth(-amount);
        if (currentHealth > 0)
        {
            OnTookHit();
        }
        else
        {
            OnDied();
        }
    }
}
