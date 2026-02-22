using HoneywellFitness.TuiThingy;

namespace HoneywellFitness.PersonalFitness.HelpFeat;

public sealed class HelpTui(ConsoleWriter cw, SystemServices system)
{
    private readonly ConsoleWriter _console = cw;
    private readonly SystemServices _system = system;

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
                _system.NavigatorSwitchContext(TuiContext.MainMenu);
                return true;
        }
        return true;
    }

    private void Print()
    {
        Console.Clear();
        _console.SetPos(_console.MaxX / 2 - 10, 10);
        Console.Write("yeah buddy, light weight!");
    }
}
