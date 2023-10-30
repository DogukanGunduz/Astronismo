using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    public GameObject loadingScreen;



    public async void LoadScene(string sceneName)
    {
        var scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;
        loadingScreen.SetActive(true);
        
        do
        {
            await Task.Delay(4000);
        } while (scene.progress<0.9f);
        scene.allowSceneActivation = true;
        await Task.Delay(1000);
        //loadingScreen.SetActive(false);
    }





}
