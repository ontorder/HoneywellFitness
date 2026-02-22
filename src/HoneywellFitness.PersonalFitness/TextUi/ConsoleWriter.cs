namespace HoneywellFitness.TextUi;

public sealed class ConsoleWriter
{
    public int MaxX => _maxX;
    public int MaxY => _maxY;

    private int _maxX = 49;
    private int _minX = 0;
    private int _maxY = 79;
    private int _minY = 0;

    public void Init(int width, int height)
    {
        _maxX = width - 1;
        _maxY = height - 1;
    }

    public void SetPos(int x, int y)
    {
        if (x > _maxX) x = _maxX;
        if (y > _maxY) y = _maxY;
        if (x < _minX) x = _minX;
        if (y < _minY) y = _minY;
        Console.Write(Vt100.AbsolutePosition(x, y));
    }
}
