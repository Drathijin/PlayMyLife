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

    string dir = "saves.txt";
    
    //Carga de un txt el estado del último guardado, en caso de que no haya dicho txt devuelve nivel 1 y el resto bloqueados
    public LevelsList LoadGame(int levels) 
    {
        LevelsList ActualList = new LevelsList { levels = new LevelState[levels], act = 0};
        for (int i = 0; i < ActualList.levels.Length; i++) ActualList.levels[i] = 0;
        return ActualList;
    }

    //Guarda en un txt el estado del juego
    public void SaveGame()
    {

    }

    //Devuelve el último nivel sin bloquear
    public int ActualLevel(ref LevelsList ActualList)
    {
        int i = 0;
        while (ActualList.levels[i] != LevelState.Locked) i++;
        if (i<ActualList.act) ActualList.act = i;
        return i;
    }

    //Guarda una victoria o una derrota (dependiendo del bool) en la lista
    public void SaveLevel(bool win, ref LevelsList ActualList)
    {
        if (win) ActualList.levels[ActualList.act] = LevelState.Win;
        else ActualList.levels[ActualList.act] = LevelState.Lost;
        ActualList.act++;
    }
}
