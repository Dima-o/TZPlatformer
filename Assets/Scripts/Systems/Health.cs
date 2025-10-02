using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private TMP_Text textHealth;
    [SerializeField] private Image LinerBar;
    public float maxHealth = 100f;
    
    private float _damage;
    public bool IsAlive => maxHealth > 0;

    private float _realTextHealth;



    private void Update()
    {
        HealthDisplay();
    }

    private void HealthDisplay()
    {
        _realTextHealth = LinerBar.fillAmount * 100;
        _realTextHealth = Mathf.Clamp(maxHealth, 0, 100);

        textHealth.text = _realTextHealth.ToString();
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        _damage = damage;
        LinerBar.fillAmount = maxHealth / 100;

        if (maxHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {


    }
}
