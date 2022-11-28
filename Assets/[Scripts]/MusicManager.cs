using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public enum TrackID
    {
        WILD,
        BATTLE
    }
    private MusicManager() { }

    private static MusicManager instance = null;
    public static MusicManager Instance
    {
        get 
        {
            if (instance == null)
            {
                instance =  FindObjectOfType<MusicManager>();
                UnityEngine.SceneManagement.SceneManager.sceneLoaded += instance.OnSceneLoaded;
            }
            return instance;
        }

        private set
        {
            instance = value;
        }
    }

    [SerializeField]
    AudioSource musicSourse1;

    [SerializeField]
    AudioSource musicSourse2;

    [Range(0.0f,1.0f)]
    public float Volume;

    public AudioClip[] tracks;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        MusicManager originial = Instance;

        MusicManager[] mangers = GameObject.FindObjectsOfType<MusicManager>();
        foreach (MusicManager manger in mangers)
        {
            if (manger != originial)
            {
                Destroy(manger.gameObject);
            }
        }

        if (this == originial)
        {
            DontDestroyOnLoad(gameObject);
        }

        if (!musicSourse1.isPlaying && !musicSourse2.isPlaying)
        {
            musicSourse1.Play();
            musicSourse1.volume = Volume;
        }
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Game")
        {
            CrossFadeTo(TrackID.WILD);
        }
        if (scene.name == "BattleScene")
        {
            CrossFadeTo(TrackID.BATTLE);
        }
    }

    public void CrossFadeTo(TrackID goalTrack, float duration = 1.0f)
    {
        AudioSource oldTrack = musicSourse1;
        AudioSource newTrack = musicSourse2;
        if (musicSourse1.isPlaying)
        {
            oldTrack = musicSourse1;
            newTrack = musicSourse2;
        }
        else if(musicSourse2.isPlaying)
        {
            oldTrack = musicSourse2;
            newTrack = musicSourse1;
        }
        newTrack.clip = tracks[(int)goalTrack];
        newTrack.Play();
        newTrack.volume = Volume;
        StartCoroutine(CrossFadeCoroutine(oldTrack, newTrack, duration));
    }

    private IEnumerator CrossFadeCoroutine(AudioSource oldTrack, AudioSource newTrack, float duration)
    {
        float time = 0.0f;
        while (time < duration)
        {
            float tValue = time / duration;
            newTrack.volume = tValue;
            oldTrack.volume = Volume - tValue;
            time += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        oldTrack.Stop();
        oldTrack.volume = Volume;
    }
}
