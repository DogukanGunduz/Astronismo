using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class GamePlayScenesMusicManager : MonoBehaviour
{
    private async void Start()
    {
        
        await Task.Delay(200);
        FindObjectOfType<SFXPlayer>().PlayGameSceneMusic();
        FindObjectOfType<SFXPlayer>().StopMainMenuMusic();
    }
}
