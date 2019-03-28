public class Save
{
    Level[] levels;
    int act; //nivel actual
    int tam;

    // -----Constructores----- //

    public Save( int tam, int Act, LevelState[] states) //inicializa un guardado  con todas las variables dadas
    {
        levels = new Level[tam];
        for (int i = 0; i < levels.Length; i++)
            levels[i] = new Level(i, states[i]);
        act = Act;
    }

    public Save(int tam) //inicializa un guardado con cada nivel bloqueado
    {
        levels = new Level[tam];
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
    public void SaveLevel(Save save, Level level)
    {
        save.levels[level.GetNum()] = new Level(level.GetNum(), level.GetState());
    }

    public int GetAct() { return act; }
    public void SetAct(int Act) { act = Act; }

    public Level[] GetLevels()
    {
        return levels;
    }
}
