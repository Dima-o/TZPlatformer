using UnityEngine;

public class HealthPlayer : HealthSystem
{
    [SerializeField] private DeathPlayer deathPlayer;
    [SerializeField] private AudioSource audioDamage;

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
        if (!audioDamage.isPlaying)
        {
            audioDamage.Play();
        }
    }

    protected override void Die()
    {
        base.Die();
        deathPlayer.Death();
    }
}
