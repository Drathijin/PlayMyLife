public class Save
{
    Level[] levels;
    int act; //nivel actual en el que se encuentra el guardado
    int tam; //tamaño del array de niveles

    // -----Constructores----- //

    public Save( int tam, int Act, LevelState[] states) //inicializa un guardado  con todas las variables dadas
    {
        levels = new Level[tam];
        //levels[0] = new Level(0,(LevelState)2); //inicializamos el menú principal, lvl0, a victoria siempre
        for (int i = 0; i < levels.Length; i++)
            levels[i] = new Level(i, states[i]);
        act = Act;
    }

    public Save(int tam) //inicializa un guardado con cada nivel bloqueado
    {
        levels = new Level[tam];
        //levels[0] = new Level(0,(LevelState)2); //inicializamos el menú principal, lvl0, a victoria siempre
        for (int i = 0; i < levels.Length; i++)
            levels[i] = new Level(i);
        act = 0; 
    }

    // -----FinDConstructores----- //


        /// <summary>
        /// Guarda en el save el nivel actual
        /// </summary>
        /// <param name="save"></param>
        /// <param name="level"></param>
    public void SaveLevel(Level level)
    {
        levels[level.GetNum()] = level;
    }

    public int GetAct() { return act; }
    public int FindAct()
    {
        int i = 0;
        LevelState state = levels[0].GetState();
        while (i< levels.Length && state != LevelState.Locked)
        {
            i++;
            state = levels[i].GetState();
        }
        return i;
    }
    public void SetAct(int Act) { act = Act; }

    public Level[] GetLevels()
    {
        return levels;
    }
    public void ChangeLevel(int Act, LevelState state)
    {
        levels[Act].SetState(state);
    }
}
