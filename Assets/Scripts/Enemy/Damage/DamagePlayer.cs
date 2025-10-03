using player.Inputs;
using UnityEngine;

public class DamagePlayer : Damage
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private float knockbackForce;
    [SerializeField] private float knockbackUpward;
    [SerializeField] private float stunDuration;

    protected override string TargetTag => "Player";

    private float lastAttackTime;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(TargetTag))
        {
            if (Time.time >= lastAttackTime + attackCooldown)
            {
                base.OnTriggerEnter2D(collision);
                lastAttackTime = Time.time;

                Rigidbody2D rb = collision.attachedRigidbody;
                Vector2 direction = (collision.transform.position - transform.position).normalized;

                Vector2 knockback = new Vector2(direction.x * knockbackForce, knockbackUpward);

                rb.velocity = Vector2.zero;
                rb.AddForce(knockback, ForceMode2D.Impulse);

                PlayerInput input = collision.GetComponent<PlayerInput>();
                if (input != null)
                {
                    input.StartCoroutine(DisableControl(input));
                }
            }
        }
    }

    private System.Collections.IEnumerator DisableControl(PlayerInput input)
    {
        input.enabled = false;
        yield return new WaitForSeconds(stunDuration);
        input.enabled = true;
    }
}
