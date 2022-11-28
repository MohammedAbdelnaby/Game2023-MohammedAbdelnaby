using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
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
        SceneManager.LoadScene("Game");
    }

    public void NewWorld()
    {
        PlayerPrefs.SetFloat("X", 0.0f);
        PlayerPrefs.SetFloat("Y", 0.0f);
        PlayerPrefs.SetFloat("Z", 0.0f);
        SceneManager.LoadScene("Game");
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
