using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    UIManager theUIManager;
    WinManagger theWinManager;

    //bool winOnTimeOut, win;
    //int collected=0, maxCollected,score=0;
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
        theUIManager.SeeTime(theWinManager.maxSeconds);
    }
    public void Collectable()
    {
        theUIManager.PlayerCollected(theWinManager.GetCollectables(), theWinManager.maxCollectables);
    }
    public void AddPoints()
    {
        theUIManager.PlayerPoints(theWinManager.GetKillCount());
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

    public void PointsManager(int points, int minPoints)
    {
        theUIManager.PlayerPoints(points);
    }
    public void WinLevel()
    {
        nivel++;
        print(nivel);
        SceneManager.LoadScene(nivel);
    }
    public void LoseLevel()
    {
        nivel++;
        SceneManager.LoadScene(nivel);

    }

    public void AddCollectable()
    {
        theWinManager.AddCollectable();
    }
    public void KillEnemy()
    {
        theWinManager.SubKillCount();
    }

}
