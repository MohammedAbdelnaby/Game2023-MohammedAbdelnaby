using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BushBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            if (Random.value < 0.5f)
            {
                Debug.Log("Battle");
                SceneManager.LoadScene("BattleScene");
            }
        }
    }
}
