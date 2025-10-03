using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] private TMP_Text textHealth;
    [SerializeField] private Image LinerBar;
    [SerializeField] private float maxHealth = 100f;
    
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

    public virtual void TakeDamage(float damage)
    {
        maxHealth -= damage;
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
