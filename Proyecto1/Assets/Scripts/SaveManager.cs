﻿using System.IO;
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
        SaveGame(LoadGame(12));
    }
    //Carga de un txt el estado del último guardado, en caso de que no haya dicho txt devuelve nivel 1 y el resto bloqueados
    public LevelsList LoadGame(int levels) 
    {

        LevelsList actualList = new LevelsList { levels = new LevelState[levels], act = 0};
        for (int i = 0; i < actualList.levels.Length; i++) actualList.levels[i] = 0;
        return actualList;
    }

    //Guarda en un txt el estado del juego
    public void SaveGame(LevelsList actualList)
    {
        StreamWriter writer = new StreamWriter(dir);
        writer.WriteLine(actualList.act);
        foreach(LevelState level in actualList.levels)
        writer.WriteLine(level);
        writer.Close();
    }

    //Devuelve el último nivel sin bloquear
    public int ActualLevel(ref LevelsList actualList)
    {
        int i = 0;
        while (actualList.levels[i] != LevelState.Locked) i++;
        if (i<actualList.act) actualList.act = i;
        return i;
    }

    //Guarda una victoria o una derrota (dependiendo del bool) en la lista
    public void SaveLevel(bool win, ref LevelsList actualList)
    {
        if (win) actualList.levels[actualList.act] = LevelState.Win;
        else actualList.levels[actualList.act] = LevelState.Lost;
        actualList.act++;
    }
}
