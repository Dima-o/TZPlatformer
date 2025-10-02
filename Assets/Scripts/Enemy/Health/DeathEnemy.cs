using UnityEngine;

public class DeathEnemy : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D[] capsuleCollider;
    [SerializeField] private float timeDeath;

    private Rigidbody2D rb;
    private EnemyAnimationsSetup animSetup;
    private bool isActiveTimerDeath;

    private void Start()
    {
        animSetup = GetComponent<EnemyAnimationsSetup>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isActiveTimerDeath)
        {
            timeDeath -= Time.deltaTime;
            if (timeDeath <= 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Death()
    {
        animSetup.AnimDeath();
        OffCapsuleCollider();
        rb.isKinematic = true;
        isActiveTimerDeath = true;
    }

    private void OffCapsuleCollider()
    {
        for (int i = 0; i < capsuleCollider.Length; i++)
        {
            capsuleCollider[i].enabled = false;
        }
    }
}
