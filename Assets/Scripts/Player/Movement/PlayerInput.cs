using UnityEngine;

namespace player.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private PlayerMovement playerMovement;
        private Shooter shooter;

        private float horizontalDirection;
        private bool jumpPressed;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            shooter = GetComponent<Shooter>();
        }

        private void Update()
        {
            horizontalDirection = Input.GetAxis(GloballStringVars.horizontalAxis);

            if (Input.GetButtonDown(GloballStringVars.jump))
            {
                jumpPressed = true;
            }

            if (Input.GetButtonDown(GloballStringVars.fire1))
            {
                shooter.StartAnimation();
            }
        }

        private void FixedUpdate()
        {
            playerMovement.Move(horizontalDirection, jumpPressed);

            jumpPressed = false;
        }
    }
}
