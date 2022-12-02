using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BushBehavior : MonoBehaviour
{
    private LevelChanger TransitionUI;

    private void Start()
    {
        TransitionUI = GameObject.FindObjectOfType<LevelChanger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Random.value < 0.2f)
            {
                if (TransitionUI != null)
                    TransitionUI.FadeToLevel(3);
            }
        }
    }
}
