using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;// = null;
    string dir = "./saves.txt";
    const int LVLS = 12; //Numero de niveles por defecto a cargar
    static private Save currentGame;

    private void Awake()
    {
        currentGame = LoadGame();
    }

    private void Start()
    {
        GameManager.instance.SetSaveManager(this);
    }

    /// <summary>
    /// Busca en la dirección dir el archivo de texto donde está guardada la partdia y la carga en una variable "Save" que devuelve.
    /// </summary>
    /// <returns></returns>
    public Save LoadGame()
    {
        Save save = new Save(LVLS);
        if (!File.Exists(dir))return save;
        StreamReader reader = new StreamReader(dir);
        int i = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            LevelState redState = (LevelState)Enum.Parse(typeof(LevelState), line);
            Level newLevel = new Level(i, redState);
            save.SaveLevel(newLevel);
            print(redState);
            i++;
        }
        int act = save.FindAct();
        save.SetAct(act);
        print(act);
        reader.Close();
        return save;
    }

    /// <summary>
    /// Guarda en el archivo de texto el estado actual del objeto save
    /// </summary>
    /// <param name="actState"></param>
    public void SaveGame()
    {
        //if (!File.Exists(dir)) File.Create(dir);
        StreamWriter writer = new StreamWriter(dir);
        foreach (Level level in currentGame.GetLevels())
        {
            writer.WriteLine(level.GetState());
            //print(level.GetState());
        }
        writer.Close();

    }
    public void FinishLevel(bool win)
    {
        currentGame.GetLevels()[currentGame.GetAct()].FinishLevel(win);
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
    }
}
