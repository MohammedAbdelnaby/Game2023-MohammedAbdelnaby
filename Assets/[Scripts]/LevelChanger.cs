using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


//Source: https://www.youtube.com/watch?v=Oadq-IrOazg
public class LevelChanger : MonoBehaviour
{
    public Animator animator;

    private int LevelToLoad;

    public void FadeToLevel(int LevelIndex)
    {
        LevelToLoad = LevelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(LevelToLoad);
    }
}
