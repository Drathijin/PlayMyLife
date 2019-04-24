using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    UIManager theUIManager;
    WinManager theWinManager;
    //AudioManager theAudioManager;
    SaveManager theSaveManager;


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }

    }
    private void Update()
    {
        if (theWinManager != null && theWinManager.maxSeconds > -1 && theUIManager != null) theUIManager.SeeTime(theWinManager.GetTime(), theWinManager.maxSeconds);
    }


    public void SetSaveManager(SaveManager saveManager)
    {
        theSaveManager = saveManager;
    }
    public void SetUIManager(UIManager UIManager)
    {
        theUIManager = UIManager;
        Pause();
        theUIManager.StartLevel();

    }

    /*public void SetAudioManager(AudioManager AudioManager)
    {
        theAudioManager = AudioManager;
    }*/

    public void SetWinManager(WinManager winMan)
    {
        theWinManager = winMan;
    }


    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }


    public void ExitGame()
    {
        Application.Quit();
    }


    public void FinishLevel(bool win)
    {
        theSaveManager.FinishLevel(win);
        theUIManager.FinishLevel(win, theSaveManager.GetAct());
        Invoke("Pause", 1.5f);
        theSaveManager.SaveGame();
    }

    public void LoadLevel(int n)
    {
        Pause();
        SceneManager.LoadScene(n);
        theSaveManager.LoadGame();

    }

    public void AddCollectable()
    {
        theWinManager.AddCollectable();
        theUIManager.PlayerCollected(theWinManager.GetCollectables(), theWinManager.maxCollectables);
    }
    public void KillEnemy()
    {
        if (theWinManager.maxKills > -1)
        {
            theWinManager.SubKillCount();
            theUIManager.PlayerKills(theWinManager.GetKillCount());
        }
    }
    public void LoadGame()
    {
        theSaveManager.LoadGame();
        LoadLevel(theSaveManager.GetAct());
    }
    public void NewGame()
    {
        theSaveManager.NewSave();
        LoadLevel(1); //empieza en la escena 1 porque la 0 es el menú principal
    }
    /*public void SetVolume(float volume)
    {
        theAudioManager.SaveVolume(volume);
    }

    public void PlayClip(string name)
    {
        theAudioManager.Play(name);
    }*/

    public void Pause() 
    {
        Time.timeScale = 0f;
    }
    public void Play() 
    {
        Time.timeScale = 1f;
    }
}