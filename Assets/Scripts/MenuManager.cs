using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject main;
    public GameObject option;

    public Slider[] volumeSliders;
    

    public void Start()
    {
        foreach (var item in volumeSliders)
        {
            item.value = 1f;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public void MainMenu()
    {
        main.SetActive(true);
        option.SetActive(false);
    }

    public void OptionMenu()
    {
        main.SetActive(false);
        option.SetActive(true);
    }

    public void SetMasterVolume(float value)
    {
        GameManager.MasterVolume = value;
    }
    public void SetSfxVolume(float value)
    {
        GameManager.SfxVolume = value;
    }
    public void SetMusicVolume(float value)
    {
        GameManager.MusicVolume = value;
    }

}
