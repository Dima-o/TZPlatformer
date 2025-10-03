using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButtons : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuPause;
    [SerializeField] private AudioSource audioBackground;
    [SerializeField] private AudioSource audioClick;

    public void ButtonExit()
    {
        audioClick.Play();
        StartCoroutine(ExitTheGame(0.1f));
    }

    public void ButtonAgain()
    {
        audioClick.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, SceneManager.GetActiveScene().buildIndex));
        Time.timeScale = 1;
    }

    public void ButtonPlay()
    {
        audioClick.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 1));
    }

    public void ButtonInMenu()
    {
        Time.timeScale = 1;
        audioClick.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 0));
    }

    public void ButtonPause()
    {
        Time.timeScale = 0;
        audioClick.Play();
        audioBackground.Pause();
        menuPause.SetActive(true);
    }

    public void ButtonContinue()
    {
        Input.ResetInputAxes();
        Time.timeScale = 1;
        menuPause.SetActive(false);
        audioClick.Play();
        audioBackground.UnPause();
    }

    public void ButtonNextLevel()
    {
        Time.timeScale = 1;
        audioClick.Play();
        StartCoroutine(LoadNextSceneAfterTime(0.1f, SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadNextSceneAfterTime(float time, int index)
    {
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(index);
    }

    IEnumerator ExitTheGame(float time)
    {
        yield return new WaitForSeconds(time);
        EditorApplication.isPlaying = false;
    }
}