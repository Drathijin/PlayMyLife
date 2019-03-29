using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    UIManager theUIManager;
    WinManager theWinManager = null;
    SaveManager theSaveManager;
    Save save;
    Level level;

    private static int lvlNum = 0; //empieza en el nivel 0


    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }

    }
    private void Update()
    {
        if(theWinManager != null && theWinManager.maxSeconds>-1)theUIManager.SeeTime(theWinManager.GetTime(), theWinManager.maxSeconds);
    }


    public void SetSaveManager(SaveManager saveManager)
    {
        theSaveManager = saveManager;
        save = theSaveManager.LoadGame();
        lvlNum = SceneManager.GetActiveScene().buildIndex;
        level = new Level(lvlNum);

    }
    public void SetUIManager(UIManager UIManager)
    {
        theUIManager = UIManager;
    }


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
        level.FinishLevel(win);
        save.SaveLevel(save, level); 
        theSaveManager.SaveGame(save); //para probar que funciona el txt, lo mejor será hacer esto periodicamente y no cada nivel

        lvlNum++;
        //save.SetAct(lvlNum);
        print(lvlNum);
        level = new Level(lvlNum);

        theUIManager.FinishLevel(win, lvlNum);
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