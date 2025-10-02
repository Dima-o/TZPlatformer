using player.Inputs;
using UnityEngine;

public class DeathPlayer : MonoBehaviour
{
    [SerializeField] private PlayerAnimationsSetup animSetup;
    [SerializeField] private float timeDeath;

    private PlayerMovement playerMovement;

    private bool isActiveTimerDeath;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (isActiveTimerDeath)
        {
            timeDeath -= Time.deltaTime;
            if (timeDeath <= 0)
            {
                isActiveTimerDeath = false;
                TheEndGame();
            }
        }
    }

    public void Death()
    {
        playerMovement.IsActiveMove(false);
        animSetup.AnimDeath();
        isActiveTimerDeath = true;
    }

    public void TheEndGame()
    {
        Time.timeScale = 0; 
    }
}
