using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SFXPlayer : MonoBehaviour
{

    public AudioClip alienDeath;
    public AudioClip buttonClick;
    public AudioClip death;
    public AudioClip doorOpen;
    public AudioClip fall;
    public AudioClip footStepLoop;
    public AudioClip jump;
    public AudioClip portalPass;
    public AudioClip success;
    public AudioClip mainMenuMusic;
    public AudioClip gameSceneMusic;
    public AudioClip kickSound;
    AudioSource audioSource;
    AudioSource audioSourceForDoor;
    public AudioSource audioSourceForFootSteps;
    AudioSource audioSourceForPortal;
    AudioSource audioSourceForJump;
    AudioSource audioSourceForMainMenu;
    AudioSource audioSourceForGameSceneMusic;
    AudioSource audioSourceForKick;
    public AudioClip doorPass;
    AudioSource audioSourceForDoorPass;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSourceForDoor = gameObject.AddComponent<AudioSource>();
        audioSourceForDoor.playOnAwake = false;

        audioSourceForFootSteps = gameObject.AddComponent<AudioSource>();
        audioSourceForFootSteps.playOnAwake = false;

        audioSourceForPortal = gameObject.AddComponent<AudioSource>();
        audioSourceForPortal.playOnAwake = false;

        audioSourceForJump = gameObject.AddComponent<AudioSource>();
        audioSourceForJump.playOnAwake = false;

        audioSourceForMainMenu = gameObject.AddComponent<AudioSource>();
        audioSourceForMainMenu.playOnAwake = true;

        audioSourceForGameSceneMusic = gameObject.AddComponent<AudioSource>();
        audioSourceForGameSceneMusic.playOnAwake = true;

        audioSourceForKick = gameObject.AddComponent<AudioSource>();
        audioSourceForKick.playOnAwake = false;

        audioSourceForDoorPass = gameObject.AddComponent<AudioSource>();
        audioSourceForDoorPass.playOnAwake = false;


    }

    public void PlayAlienDeath()
    {
        audioSource.clip = alienDeath;
        audioSource.Play();
    }
    public void PlayButtonClick()
    {
        audioSource.clip = buttonClick;
        audioSource.Play();
    }
    public void PlayDeath()
    {
        audioSource.clip = death;
        audioSource.Play();
    }
    public void PlayDoorOpen()
    {
        audioSourceForDoor.clip = doorOpen;
        audioSourceForDoor.Play();
        
    }
    public void PlayFall()
    {
        audioSource.clip = fall;
        audioSource.Play();
    }
    public void PlayFootStepLoop()
    {
        audioSourceForFootSteps.clip = footStepLoop;
        audioSourceForFootSteps.Play();
    }
    public void StopFootStepLoop()
    {
        audioSourceForFootSteps.clip = footStepLoop;
        audioSourceForFootSteps.Stop();
    }
    public void PlayJump()
    {
        audioSourceForJump.clip = jump;
        audioSourceForJump.Play();
    }
    public void PlayPortalPass()
    {
        audioSourceForPortal.clip = portalPass;
        audioSourceForPortal.Play();
        audioSourceForFootSteps.volume = 0f;
    }
    public void PlaySuccess()
    {
        audioSource.clip = success;
        audioSource.Play();
    }

    public void PlayGameSceneMusic()
    {
        audioSourceForGameSceneMusic.clip = gameSceneMusic;
        audioSourceForGameSceneMusic.Play();
    }

    public void StopGameSceneMusic()
    {
        audioSourceForGameSceneMusic.clip = gameSceneMusic;
        audioSourceForGameSceneMusic.Stop();
    }

    public void PlayMainMenuMusic()
    {
        audioSourceForMainMenu.clip = mainMenuMusic;
        audioSourceForMainMenu.Play();
    }

    public void StopMainMenuMusic()
    {
        audioSourceForMainMenu.clip = mainMenuMusic;
        audioSourceForMainMenu.Stop();
    }

    public void PlayKickSound()
    {
        audioSourceForKick.clip = kickSound;
        audioSourceForKick.Play();
    }

    public void PlayDoorPass()
    {
        audioSourceForDoorPass.clip = doorPass;
        audioSourceForDoorPass.Play();
    }

    public void VolumeUp()
    {
        if (audioSource.volume != 1)
        {
            audioSource.volume +=0.25f;
            if (audioSource.volume > 1)
            {
                audioSource.volume = 1;
            }
        }

        Debug.Log("SFX Sound: " + audioSource.volume);

    }

    public void VolumeDown()
    {
        if (audioSource.volume != 0)
        {
            audioSource.volume -= 0.25f;
            if (audioSource.volume < 0)
            {
                audioSource.volume = 0;
            }
        }
        Debug.Log("SFX Sound: " + audioSource.volume);


    }

}
