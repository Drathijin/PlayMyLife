using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    UIManager theUIManager;
    WinManagger theWinManager;

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
    public void Collectable()
    {
        //theUIManager.PlayerCollected(theWinManager.GetCollectables(), theWinManager.maxCollectables);
    }
    public void AddPoints()
    {
        //theUIManager.PlayerPoints(theWinManager.GetKillCount());
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);

    }

    public void SetUIManager(UIManager UIManager)
    {
        theUIManager = UIManager;
    }


    public void SetWinManager(WinManagger winMan)
    {
        theWinManager = winMan;
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    /*public void PointsManager(int points, int minPoints)
    {
        theUIManager.PlayerPoints(points);
    }*/
    public void WinLevel()
    {
        nivel = (nivel + 1) % SceneManager.sceneCountInBuildSettings;
        print(nivel);
        SceneManager.LoadScene(nivel);
    }
    public void LoseLevel()
    {
        nivel = (nivel + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nivel);

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