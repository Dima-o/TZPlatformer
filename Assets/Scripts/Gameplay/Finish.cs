using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject menuVictory;
    [SerializeField] private Button buttonNextLevel;
    [SerializeField] private BoxCollider2D boxCollider2D;
    [SerializeField] private AudioSource audioVictory;
    [SerializeField] private AudioSource audioBackground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            menuVictory.SetActive(true);
            CheckingIndexLevel();
            boxCollider2D.enabled = false;
            audioBackground.Stop();
            audioVictory.Play();
            
            Time.timeScale = 0;
        }
    }

    private void CheckingIndexLevel()
    {
        int lastIndex = SceneManager.sceneCountInBuildSettings - 1;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == lastIndex)
        {
            buttonNextLevel.interactable = false;
        }
    }
}
