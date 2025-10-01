using player.Inputs;
using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private SpriteRenderer spriteRendererArrow;
    [SerializeField] private float fireSpeed;

    [Header("Angle Control")]
    [SerializeField] private float currentAngle;

    //[HideInInspector] public float fireRate;
    //[HideInInspector] public int arrowDamage;

    private PlayerMovement playerMovement;
    private GameObject _currentBullet;
    private Rigidbody2D _currentBulletVelocity;
    private PlayerAnimationsSetup animSetup;

    private float firePointPositionX;
    private float firePointPositionY;
    private float initialFirePointPositionX;

    private bool _activeShoot = true;

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
        if (_activeShoot)
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

            //if (health.IsAlive)
            _currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
            //_currentBullet.GetComponent<DamageEnemy>().damage = arrowDamage;

            
            // Задаем скорость пули
            _currentBulletVelocity = _currentBullet.GetComponent<Rigidbody2D>();

            if (_currentBulletVelocity != null)
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

            //_activeShoot = false;
        }
    }

    private void DirectionShootSpeed(float _fireSpeed, float angle)
    {
        _currentBulletVelocity.gravityScale = 1f;

        // Рассчитываем скорость по углу
        float radAngle = angle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(
            Mathf.Cos(radAngle) * _fireSpeed,
            Mathf.Sin(radAngle) * _fireSpeed
        );

        _currentBulletVelocity.velocity = velocity;
    }

    public void IsActiveShoot(bool _active)
    {
        _activeShoot = _active;
    }
}
