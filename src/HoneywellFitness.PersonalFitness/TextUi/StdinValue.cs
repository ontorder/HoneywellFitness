namespace HoneywellFitness.TextUi;

public readonly struct StdinValue(char input, bool isMeta, ConsoleKey meta)
{
    public char Input { get; } = input;
    public bool IsMeta { get; } = isMeta;
    public ConsoleKey Meta { get; } = meta;
}

