public enum LevelState
{
    Locked, Loss, Win
}
public class Level
{
    LevelState state; //El estado del nivel - Nivel bloqueado, perdido o superado.
    readonly int num; //Número del nivel
    char category; //Familiar, Académico o Social

    // -----Constructores----- //

    public Level(int Num, LevelState State, char c)
    {
        num = Num;
        state = State;
        category = c;
    }
    public Level(int Num, LevelState State)
    {
        num = Num;
        state = State;
        category = 'p'; //valor nulo por defecto
    }

    public Level(int Num)
    {
        num = Num;
        state = 0; //bloqueado
        category = 'p'; //valor nulo por defecto
    }
    public Level(int Num, char c)
    {
        num = Num;
        state = 0; //bloqueado
        category = c; //valor nulo por defecto
    }

    // -----FinDeConstructores----- //


    public int GetNum() { return num; }
    public LevelState GetState() { return state; }
    public void SetState(LevelState State) { state = State; }


    public void FinishLevel(bool win, char c)
    {
        int d = 0;
        if (win) d = 2; //ganar
        else d = 1; //perder
        state = (LevelState)d;
        category = c;
    }
    public char GetCategory() { return category; }
}
