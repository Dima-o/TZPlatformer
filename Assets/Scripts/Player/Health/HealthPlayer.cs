using UnityEngine;

public class HealthPlayer : Health
{
    [SerializeField] private DeathPlayer deathPlayer;
    protected override void Die()
    {
        base.Die();
        deathPlayer.Death();
    }
}
