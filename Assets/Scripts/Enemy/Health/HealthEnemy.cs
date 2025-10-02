using UnityEngine;

public class HealthEnemy : Health
{
    [SerializeField] private DeathEnemy deathEnemy;

    protected override void Die()
    {
        base.Die();
        deathEnemy.Death();
    }
}
