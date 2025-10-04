using UnityEngine;

public class DamageEnemy : DamageSystem
{
    protected override string TargetTag => "DamageEnemy";

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.CompareTag(TargetTag))
        {
            Destroy(gameObject);
        }
    }
}
