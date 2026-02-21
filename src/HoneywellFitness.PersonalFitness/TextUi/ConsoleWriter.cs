namespace HoneywellFitness.TextUi;

public sealed class ConsoleWriter
{
    private int _cursorX = 0;
    private int _cursorY = 0;

    private const int MaxX = 50;
    private const int MinX = 0;
    private const int MaxY = 80;
    private const int MinY = 0;

    public void Down()
    {
        if (_cursorY == MaxY) return;
        Console.Write($"{Vt100.AbsolutePosition(_cursorX, _cursorY)}");
        ++_cursorY;
    }

    public void Up()
    {
        if (_cursorY == MaxY) return;
        Console.Write($"{Vt100.AbsolutePosition(_cursorX, _cursorY)}");
    }

    public void Set()
    {
        Console.Write($"{Vt100.AbsolutePosition(_cursorX, _cursorY)}");
    }

    public void Left()
    {
    }

    public void RIght()
    {

    }
}
