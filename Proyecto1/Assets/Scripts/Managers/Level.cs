public enum LevelState
{
    Locked, Lost, Win
}
public class Level
{
    LevelState state; //El estado del nivel - Nivel bloqueado, perdido o superado.
    readonly int num; //Número del nivel

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


    public int GetNum() { return num; }
    public LevelState GetState() { return state; }
    public void SetState(LevelState State) { state = State; }


    public void FinishLevel(bool win)
    {
        int d = 0;
        if (win) d = 2; //ganar
        else d = 1; //perder
        state = (LevelState)d;
    }
}
