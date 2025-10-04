using UnityEngine;

public class PlayerAnimationsSetup : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void AnimAttack()
    {
        animator.SetTrigger("attack");
    }

    public void AnimJump(float derictionSpeed, bool isGrounded)
    {
        animator.SetFloat("directionJump", derictionSpeed);
        animator.SetBool("isGrounded", isGrounded);
    }

    public void OffAnimJump(bool isGrounded)
    {
        animator.SetBool("isGrounded", isGrounded);
    }

    public void AnimDeath()
    {
        animator.SetTrigger("activeDeath");
    }

    public void AnimOnOffRun(bool active)
    {
        animator.SetBool("activeRun", active);
    }
}
