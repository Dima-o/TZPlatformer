using System.Collections;
using UnityEngine;

public class DeleteCoin : MonoBehaviour
{
    [SerializeField] DataCounter dataCounter;
    [SerializeField] AudioSource audioCounterCoin;
    [SerializeField] CapsuleCollider2D capsuleCollider;
    [SerializeField] SpriteRenderer spriteRendererCoin;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            spriteRendererCoin.enabled = false;
            dataCounter.CounterDataCoins();
            StartCoroutine(DelayForAudio(0.5f));
            capsuleCollider.enabled = false;
        }
    }

    private IEnumerator DelayForAudio(float time)
    {
        audioCounterCoin.Play();
        capsuleCollider.enabled = false;

        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
