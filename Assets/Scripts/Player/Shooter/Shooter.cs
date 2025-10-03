using player.Inputs;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer spriteRendererArrow;
    [SerializeField] private float fireSpeed;

    [Header("Angle Control")]
    [SerializeField] private float currentAngle;

    [Header("Audio")]
    [SerializeField] private AudioSource audioArchery;

    private PlayerMovement playerMovement;
    private GameObject currentBullet;
    private Rigidbody2D currentBulletVelocity;
    private PlayerAnimationsSetup animSetup;

    private float firePointPositionX;
    private float firePointPositionY;
    private float initialFirePointPositionX;

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        animSetup = GetComponent<PlayerAnimationsSetup>();

        firePointPositionY = firePoint.localPosition.y;
        initialFirePointPositionX = firePoint.localPosition.x;
    }

    public void StartAnimation()
    {
        animSetup.AnimAttack();
    }

    public void Shoot()
    {
        if (playerMovement.LookDirection)
        {
            firePointPositionX = -initialFirePointPositionX;
            spriteRendererArrow.flipX = true;
        }
        else
        {
            firePointPositionX = initialFirePointPositionX;
            spriteRendererArrow.flipX = false;
        }

        firePoint.localPosition = new Vector2(firePointPositionX, firePointPositionY);

        currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        audioArchery.Play();

        currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if (currentBulletVelocity != null)
        {
            if (playerMovement.LookDirection)
            {
                DirectionShootSpeed(-fireSpeed, -currentAngle);
            }
            else
            {
                DirectionShootSpeed(fireSpeed, currentAngle);
            }
        }
        else
        {
            Debug.LogWarning("Bullet prefab has no Rigidbody2D component!");
        }
    }

    private void DirectionShootSpeed(float _fireSpeed, float angle)
    {
        currentBulletVelocity.gravityScale = 1f;

        float radAngle = angle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(
            Mathf.Cos(radAngle) * _fireSpeed,
            Mathf.Sin(radAngle) * _fireSpeed
        );

        currentBulletVelocity.velocity = velocity;
    }
}
