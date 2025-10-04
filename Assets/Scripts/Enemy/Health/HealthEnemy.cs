using UnityEngine;

public class HealthEnemy : HealthSystem
{
    [SerializeField] private DeathEnemy deathEnemy;

    protected override void Die()
    {
        base.Die();
        deathEnemy.Death();
    }
}
