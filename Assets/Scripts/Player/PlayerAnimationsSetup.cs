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

    public void AnimDeath(string anim)
    {
        animator.SetBool("activeRun", false);
        animator.SetBool(anim, true);     
    }

    public void AnimOnRun()
    {
        animator.SetBool("activeRun", true);
    }

    public void AnimOffRun()
    {
        animator.SetBool("activeRun", false);
    }
}
