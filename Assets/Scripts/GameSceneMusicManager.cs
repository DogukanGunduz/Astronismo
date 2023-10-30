using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneMusicManager : MonoBehaviour
{
    private static GameSceneMusicManager musicManagerInstance;
    AudioSource audioSource;
    float volume;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        if (musicManagerInstance == null)
        {
            musicManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        volume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = volume;

    }

    private void Update()
    {
        if(SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "LevelsScene")
        {
            musicManagerInstance.GetComponent<AudioSource>().Pause();
        }
        else
        {
            musicManagerInstance.GetComponent<AudioSource>().UnPause();
        }
    }

    public void VolumeUp()
    {
        if (audioSource.volume != 1)
        {
            audioSource.volume += 0.25f;
            if (audioSource.volume > 1)
            {
                audioSource.volume = 1;
            }
            volume = audioSource.volume;
            PlayerPrefs.SetFloat("volume", volume);
        }

        Debug.Log("Sound: " + audioSource.volume);


    }

    public void VolumeDown()
    {
        if (audioSource.volume != 1)
        {
            audioSource.volume -= 0.25f;
            if (audioSource.volume < 0)
            {
                audioSource.volume = 0;
            }
            volume = audioSource.volume;
            PlayerPrefs.SetFloat("volume", volume);
        }

        Debug.Log("Sound: " + audioSource.volume);


    }
}
