using UnityEngine;

public class DeathEnemy : DeathSystem
{
    [SerializeField] private CapsuleCollider2D[] capsuleCollider;

    private Rigidbody2D rb;
    private EnemyAnimationsSetup animSetup;

    private void Start()
    {
        animSetup = GetComponent<EnemyAnimationsSetup>();
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void PlayDeathAnimation()
    {
        animSetup.AnimDeath();
    }

    protected override void OnDeathStart()
    {
        foreach (var col in capsuleCollider)
        {
            col.enabled = false;
        }
        rb.isKinematic = true;
    }

    protected override void OnDeathEnd()
    {
        Destroy(gameObject);
    }
}
