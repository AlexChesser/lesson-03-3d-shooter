using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayerHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Image fillImage;
    private Health playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerMovement>().GetComponent<Health>();
        playerHealth.OnHealthChanged += PlayerHealth_OnHealthChanged;
    }

    private void OnDestroy()
    {
        playerHealth.OnHealthChanged -= PlayerHealth_OnHealthChanged;
    }

    private void PlayerHealth_OnHealthChanged(int currentHealth, int maxHealth)
    {
        healthText.text = $"{currentHealth}/{maxHealth}";
        fillImage.fillAmount = currentHealth / maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
