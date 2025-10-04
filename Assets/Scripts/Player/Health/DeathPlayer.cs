using UnityEngine;
using player.Inputs;

public class DeathPlayer : DeathSystem
{
    [SerializeField] private PlayerAnimationsSetup animSetup;
    [SerializeField] private GameObject menuDefeat;
    [SerializeField] private AudioSource audioBackground;
    [SerializeField] private AudioSource audioDefeat;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    protected override void PlayDeathAnimation()
    {
        animSetup.AnimDeath();
    }

    protected override void OnDeathStart()
    {
        playerMovement.IsActiveMove(false);
    }

    protected override void OnDeathEnd()
    {
        menuDefeat.SetActive(true);
        audioBackground.Stop();
        audioDefeat.Play();
        Time.timeScale = 0;
    }
}
