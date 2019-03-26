using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    UIManager theUIManager;
    WinManagger theWinManager;
    SaveManager theSaveManager;
    SaveManager.LevelsList save;

    private static int nivel = 0; //empieza en el nivel 0


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }
    }
    private void Start()
    {

    }
    private void Update()
    {
        if(theWinManager.maxSeconds>-1)theUIManager.SeeTime(theWinManager.GetTime(), theWinManager.maxSeconds);
    }


    public void SetSaveManager(SaveManager saveManager)
    {
        theSaveManager = saveManager;
        save = theSaveManager.LoadGame(12);
        nivel = save.act; //SceneManager.GetActiveScene().buildIndex;

    }
    public void SetUIManager(UIManager UIManager)
    {
        theUIManager = UIManager;
    }


    public void SetWinManager(WinManagger winMan)
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

    public void WinLevel()
    {
        nivel++;
        theUIManager.FinishLevel(true, nivel);
        theSaveManager.SaveLevel(true, ref save);
        theSaveManager.SaveGame(save);

        Time.timeScale = 0f;
    }

    public void LoseLevel()
    {
        nivel++;
        theUIManager.FinishLevel(false, nivel);
        theSaveManager.SaveLevel(false, ref save);
        theSaveManager.SaveGame(save);


        Time.timeScale = 0f;
    }
    public void LoadLevel(int n)
    {
        SceneManager.LoadScene(n);
        Time.timeScale = 1f;
    }

    public void AddCollectable()
    {
        theWinManager.AddCollectable();
        theUIManager.PlayerCollected(theWinManager.GetCollectables(), theWinManager.maxCollectables);
    }
    public void KillEnemy()
    {
        if(theWinManager.maxKills >-1)
        {
            theWinManager.SubKillCount();
            theUIManager.PlayerKills(theWinManager.GetKillCount());
        }
    }

}