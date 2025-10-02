using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButtons : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject menuPause;

    public void ButtonExit()
    {
        StartCoroutine(ExitTheGame(0.1f));
    }

    public void ButtonAgain()
    {
        StartCoroutine(LoadNextSceneAfterTime(0.1f, SceneManager.GetActiveScene().buildIndex));
        Time.timeScale = 1;
    }

    public void ButtonsLevels(int level)
    {
        StartCoroutine(LoadNextSceneAfterTime(0.1f, level));
    }

    public void ButtonPlay()
    {
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 1));
    }

    public void ButtonInMenu()
    {
        Time.timeScale = 1;
        StartCoroutine(LoadNextSceneAfterTime(0.1f, 0));
    }

    public void ButtonPause()
    {
        Time.timeScale = 0;
        menuPause.SetActive(true);
    }

    public void ButtonContinue()
    {
        Time.timeScale = 1;
        menuPause.SetActive(false);
    }

    public void ButtonNextLevel()
    {
        Time.timeScale = 1;
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