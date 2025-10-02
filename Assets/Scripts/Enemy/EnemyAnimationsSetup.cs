using UnityEngine;

public class EnemyAnimationsSetup : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimDeath()
    {
        animator.SetTrigger("activeDeath");
    }

    public void AnimEnemy(float indicator)
    {
        animator.SetFloat("velocity", indicator);
    }
}
