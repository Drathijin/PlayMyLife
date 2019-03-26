using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public enum LevelState
    {
        Locked, Lost, Win
    }
    public struct LevelsList
    {
        public LevelState[] levels; //inicializar cada nivel a Locked o 0
        public int act; //nivel actual
    }

    string dir = "./saves.txt";

    private void Start()
    {
        GameManager.instance.SetSaveManager(this);
    }

    //Crea un guardado con todos los niveles en "bloqueado" y el actual como el 0
    public LevelsList NewGame(int levels)
    {
        LevelsList actualList = new LevelsList { levels = new LevelState[levels], act = 1 }; //inicializa en 1 para ignorar el menu
        for (int i = 0; i < actualList.levels.Length; i++) actualList.levels[i] = 0;
        return actualList;
    }

    //Carga de un txt el estado del último guardado, en caso de que no haya dicho txt devuelve nivel 1 y el resto bloqueados
    public LevelsList LoadGame(int levels) 
    {
        //crea una lista vacía por si no existe guardado
        LevelsList actualList = NewGame(levels);
        if (!File.Exists(dir)) return actualList;

        else //si existe carga la que hay en el txt y la devuelve
        {
            StreamReader reader = new StreamReader(dir);
            actualList.act = int.Parse(reader.ReadLine());
            int i = 0;
            while (!reader.EndOfStream)
            {
                actualList.levels[i] = (LevelState)System.Enum.Parse(typeof(LevelState), reader.ReadLine());
                i++;
            }
            reader.Close();
        }
        return actualList;

    }

    //Guarda en un txt el estado del juego
    public void SaveGame(LevelsList actualList)
    {   
        StreamWriter writer = new StreamWriter(dir);
        writer.WriteLine(actualList.act);
        //writer.WriteLine("Menu");
        foreach(LevelState level in actualList.levels)
            writer.WriteLine(level);

        /*for (int i = 0; i< actualList.levels.Length; i++)
        {
            writer.WriteLine(actualList.levels[i]);
        }*/
        writer.Close();
    }

    //Guarda una victoria o una derrota (dependiendo del bool) en la lista
    public void SaveLevel(bool win, ref LevelsList actualList)
    {
        if (win) actualList.levels[actualList.act] = LevelState.Win;
        else actualList.levels[actualList.act] = LevelState.Lost;
        print(actualList.levels[actualList.act]);
        print(actualList.act);
        actualList.act++;
    }
}
