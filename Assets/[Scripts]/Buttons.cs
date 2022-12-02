using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    private LevelChanger TransitionUI;

    private void Start()
    {
        TransitionUI = GameObject.FindObjectOfType<LevelChanger>();
    }
    public void Play()
    {
        if(TransitionUI != null)
            TransitionUI.FadeToLevel(2);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
        Time.timeScale = 0;
    }

    public void Continue()
    {
        if (TransitionUI != null)
            TransitionUI.FadeToLevel(2);
    }

    public void NewWorld()
    {
        PlayerPrefs.SetFloat("X", 0.0f);
        PlayerPrefs.SetFloat("Y", 0.0f);
        PlayerPrefs.SetFloat("Z", 0.0f);
        if (TransitionUI != null)
            TransitionUI.FadeToLevel(2);
    }

    public void Save()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            PlayerPrefs.SetFloat("X", player.transform.position.x);
            PlayerPrefs.SetFloat("Y", player.transform.position.y);
            PlayerPrefs.SetFloat("Z", player.transform.position.z);
        }
    }

}
