using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 120;
        
    }

    private async void Start()
    {
        await Task.Delay(200);
        FindObjectOfType<SFXPlayer>().PlayMainMenuMusic();
        FindObjectOfType<SFXPlayer>().StopGameSceneMusic();
    }
}
