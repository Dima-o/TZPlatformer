using UnityEngine;

public abstract class DamageSystem : MonoBehaviour
{
    [SerializeField] protected float damage = 10f;

    protected abstract string TargetTag { get; }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag))
        {
            HealthSystem health = collision.GetComponent<HealthSystem>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }
    }
}
