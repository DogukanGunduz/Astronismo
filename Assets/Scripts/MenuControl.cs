using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{

    public GameObject buttonPopup;

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadOldScreen()
    {
        SceneManager.LoadScene("LevelsScene");
    }

    public void LoadHomeScene2()
    {
        FindObjectOfType<SFXPlayer>().PlayButtonClick();
        SceneManager.LoadScene("LevelsScene11");
    }

    public void ExitGame()
    {
        FindObjectOfType<SFXPlayer>().PlayButtonClick();
        Application.Quit();
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadLevel2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadLevel3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void LoadLevel4()
    {
        SceneManager.LoadScene("Level4");
    }

    public void LoadLevel5()
    {
        SceneManager.LoadScene("Level5");
    }

    public void LoadLevel6()
    {
        SceneManager.LoadScene("Level6");
    }

    public void LoadLevel7()
    {
        SceneManager.LoadScene("Level7");
    }

    public void LoadLevel8()
    {
        SceneManager.LoadScene("Level8");
    }

    public void RemovePopUp()
    {
        Time.timeScale = 1;
        GameObject popup = GameObject.Find("Popup");
        Destroy(popup);
    }

    public void RemoveButtonPopUp()
    {
        Time.timeScale = 1;
        buttonPopup.SetActive(false);
    }

    public void OpenButtonPopUp()
    {
        Time.timeScale = 1;
        buttonPopup.SetActive(true);

    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
