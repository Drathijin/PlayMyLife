using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;// = null;
    public char category = 'p';
    string dir = "./saves.txt";
    const int LVLS = 13; //Numero de niveles por defecto a cargar
    static private Save currentGame;
    int actC;

    private void Awake()
    {
        currentGame = LoadGame();
        if (SceneManager.GetActiveScene().name != "Tutorial" && SceneManager.GetActiveScene().name != "Menu"
        && SceneManager.GetActiveScene().name != "ListsOfLevels" && SceneManager.GetActiveScene().name != "GameEnding")
            SetActToScene();
    }

    private void Start()
    {
        GameManager.instance.SetSaveManager(this);
    }

    public Save LoadGame()
    {
        Save save = new Save(LVLS);
        if (!File.Exists(dir))return save;
        StreamReader reader = new StreamReader(dir);
        int i = 0;
        while (!reader.EndOfStream)
        {
        print("asdsa");

            string[] line = reader.ReadLine().Split(' ');
            LevelState redState = (LevelState)Enum.Parse(typeof(LevelState), line[0]);
            Level newLevel = new Level(i, redState, char.Parse(line[1]));
            save.SaveLevel(newLevel);
            i++;
        }
        int act = save.FindAct();
        print(act);
        save.SetAct(act);
        reader.Close();
        return save;
    }

    public void SetActToScene()
    {
        SetAct(SceneManager.GetActiveScene().buildIndex-2);
    }

    public void SaveGame()
    {
        //if (!File.Exists(dir)) File.Create(dir);
        StreamWriter writer = new StreamWriter(dir);
        foreach (Level level in currentGame.GetLevels())
        {
            writer.WriteLine(level.GetState() + " " + level.GetCategory());
            //print(level.GetState());
        }
        writer.Close();

    }
    public void FinishLevel(bool win)
    {
        currentGame.GetLevels()[currentGame.GetAct()].FinishLevel(win, category);
        //print(currentGame.GetLevels()[currentGame.GetAct()].GetState());
    }
    public int GetAct()
    {
       return currentGame.GetAct();
    }
    public void NewSave()
    {
        File.Delete(dir);
        currentGame = new Save(LVLS);
        SaveGame();
    }
    public void SetAct(int n) 
    {
        actC = n;
        currentGame.SetAct(actC);
    }
}
