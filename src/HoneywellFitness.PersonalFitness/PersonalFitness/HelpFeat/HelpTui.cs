namespace HoneywellFitness.PersonalFitness.HelpFeat;

public sealed class HelpTui(ConsoleWriter cw)
{
    private readonly ConsoleWriter _cw = cw;

    public void Activate()
    {
        Print();
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (input)
        {
            case { IsErr: true }:
                break;

            case { Meta: ConsoleKey.Escape }:
                break;
        }
        return true;
    }

    private void Print()
    {
        Console.Clear();
        Console.Write("yeah buddy, light weight!");
    }
}
