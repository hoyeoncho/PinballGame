using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum sceneState
{
    SS_MENU,
    SS_GAME,
}

public class GameManager : MonoSingleton<GameManager>
{


    [SerializeField]
    private static int score = 0;
    public static int Score { get => score; set => score = value; }

    static float masterVolumePercent = 1f;
    public static float MasterVolume { get => masterVolumePercent; set => masterVolumePercent = value; }
    static float sfxVolumePercent = 1f;
    public static float SfxVolume { get => sfxVolumePercent; set => sfxVolumePercent = value; }
    static float musicVolumePercent = 1f;
    public static float MusicVolume { get => musicVolumePercent; set => musicVolumePercent = value; }

    public AudioClip[] bgms;

    public static sceneState sceneIndex;

    public void Awake()
    {
        sceneIndex = (sceneState)SceneManager.GetActiveScene().buildIndex;
        PlayMusic();
    }

    //music play func
    public void PlayMusic()
    {
        sceneIndex = (sceneState)SceneManager.GetActiveScene().buildIndex;
        GetComponent<AudioSource>().clip = bgms[(int)sceneIndex];
        GetComponent<AudioSource>().volume = MasterVolume * MusicVolume * 100 ;
        GetComponent<AudioSource>().Play();
        
    }

    //effect sound play func
    public void PlaySound(AudioClip clip, Vector3 pos)
    {
        if(clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos, (masterVolumePercent * sfxVolumePercent)/100);
        }
    }



}
