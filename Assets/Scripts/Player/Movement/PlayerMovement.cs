using UnityEngine;

namespace player.Inputs
{
    [RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement vars")]
        [SerializeField] private float jumpForce;
        [SerializeField] private bool isGrounded = false;

        [Header("Settings")]
        [SerializeField] private Transform groundCheck;
        [SerializeField] private AnimationCurve curve;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private float groundCheckRadius;
        [SerializeField] private float maxAcceleration;
        [SerializeField] private float minAirAcceleration;

        private SpriteRenderer spriteRenderer;
        private Rigidbody2D rb;
        private PlayerAnimationsSetup animSetup;

        private float desiredVelocity;
        private bool activeMove;

        public bool LookDirection => spriteRenderer.flipX;

        private void Update()
        {
            rb = GetComponent<Rigidbody2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animSetup = GetComponent<PlayerAnimationsSetup>();

            isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundMask);
            activeMove = true;
        }

        public void Move(float direction, bool isJumpButtonPressed)
        {
            if (!activeMove) return;

            float verticalSpeed = rb.velocity.y;

            if (!isGrounded)
            {
                animSetup.AnimJump(verticalSpeed, isGrounded);
            }
            else
            {
                animSetup.OffAnimJump(true);
            }

            if (isJumpButtonPressed)
            {
                Jump();
            }

            if (Mathf.Abs(direction) > 0.01f)
            {
                HorizontalMovement(direction);
            }
            else
            {
                animSetup.AnimOffRun();
            }
        }

        private void Jump()
        {
            if (isGrounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        private void HorizontalMovement(float direction)
        {
            if (isGrounded)
            {
                animSetup.AnimOnRun();

            }
            else
            {
                animSetup.AnimOffRun();

            }

            desiredVelocity = curve.Evaluate(direction);

            var acceleration = isGrounded ? maxAcceleration : minAirAcceleration;
            var velocity = rb.velocity;
            var maxSpeedChange = acceleration * Time.fixedDeltaTime;

            velocity.x = Mathf.MoveTowards(velocity.x, desiredVelocity, maxSpeedChange);
            rb.velocity = velocity;

            if (direction > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction < 0)
            {
                spriteRenderer.flipX = true;
            }
        }

        public void FreezingMove(bool active)
        {
            activeMove = active;
        }

        private void OnDrawGizmosSelected()
        {
            if (groundCheck != null)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
            }
        }
    }
}