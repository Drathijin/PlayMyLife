public enum LevelState
{
    Locked, Lost, Win
}
public class Level
{
    LevelState state; //El estado del nivel - Nivel superado, perdido o bloqueado.
    int num; //Nivel actual en el que se encuentra el guardado.

    // -----Constructores----- //

    public Level(int Num, LevelState State)
    {
        num = Num;
        state = State;
    }
    public Level(int Num)
    {
        num = Num;
        state = 0; //bloqueado
    }

    // -----FinDeConstructores----- //


    public int GetNum()
    {
        return num;
    }
    public LevelState GetState() { return state; }


    public void FinishLevel(bool win)
    {
        int d = 0;
        if (win) d = 2; //ganar
        else d = 1; //perder
        state =(LevelState)d;
    }
}
