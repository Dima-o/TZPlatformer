//using UnityEngine;

//public class EnemyControler : MonoBehaviour
//{   
//    [SerializeField] private SpriteRenderer sp;
//    [SerializeField] private float speed, timeToRevert;

//    private Health health;
//    private AnimationsSetup animationsSetup;
//    private Rigidbody2D rb;

//    private const float idleState = 0;
//    private const float runState = 1;
//    private const float revertState = 2;

//    private float currentState, currentTimeToRevert;
//    private void Start()
//    {
//        animationsSetup = GetComponent<AnimationsSetup>();
//        rb = GetComponent<Rigidbody2D>();
//        health = GetComponent<Health>();
//        currentState = runState;
//        currentTimeToRevert = 0;
//    }

//    private void FixedUpdate()
//    {
//        if (currentTimeToRevert >= timeToRevert)
//        {
//            currentTimeToRevert = 0;
//            currentState = revertState;
//        }

//        if (health.IsAlive)
//        {
//            switch (currentState)
//            {
//                case idleState:
//                    rb.velocity = Vector2.zero;
//                    currentTimeToRevert += Time.deltaTime;
//                    break;
//                case runState:
//                    rb.velocity = new Vector2(-1, rb.velocity.y) * speed;
//                    break;
//                case revertState:
//                    sp.flipX = !sp.flipX;
//                    speed *= -1;
//                    currentState = runState;
//                    break;
//            }

//            animationsSetup.AnimEnemy(rb.velocity.magnitude);
//        }
//        else
//        {
//            rb.velocity = Vector2.zero;
//        }
//    }

//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if (collision.CompareTag("EnemyStop"))
//        {
//            currentState = idleState;
//        }
//    }
//}
