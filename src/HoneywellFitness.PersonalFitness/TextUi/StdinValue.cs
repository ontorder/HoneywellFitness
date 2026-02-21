namespace HoneywellFitness.TextUi;

public readonly struct StdinValue(char input, bool isErr, ConsoleKey meta)
{
    public readonly char Input = input;
    public readonly bool IsErr = isErr;
    public readonly ConsoleKey Meta = meta;
}

