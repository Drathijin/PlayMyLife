using System;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance = null;
    string dir = "./saves.txt";
    const int LVLS = 12; //Numero de niveles por defecto a cargar

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(this.gameObject); }
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
        Save save = new Save(LVLS); //en save se guardan el estado de los niveles
        if (!File.Exists(dir))
        {
            return save; //si no existe el archivo devuelve un save estándar
        }

        StreamReader reader = new StreamReader(dir);

        int i = 0;
        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine();
            LevelState state = (LevelState)Enum.Parse(typeof(LevelState), line);
            Level redLevel = new Level(i, state);
            save.SaveLevel(save, redLevel); //guarda en el save el nivel que acaba de leer
            i++;
        }
        reader.Close();
        return save;

    }

    /// <summary>
    /// Guarda en el archivo de texto el estado actual del objeto save
    /// </summary>
    /// <param name="actState"></param>
    public void SaveGame(Save actState)
    {
        StreamWriter writer;
        //if (!File.Exists(dir)) File.Create(dir);
        writer = new StreamWriter(dir);

        for (int i = 0; i < actState.GetLevels().Length; i++)
            writer.WriteLine(actState.GetLevels()[i].GetState());
        writer.Close();

    }

}
