namespace HoneywellFitness.PersonalFitness.MainMenuFeat;

public sealed class MainMenuTui(ConsoleWriter console)
{
    private readonly ConsoleWriter _console = console;
    private int _selectedOption = 0;

    public void Activate()
    {
        Reset();
        Print();
        InitCursor();
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (input)
        {
            case { IsErr: true }:
                // TODO timed error message
                break;

            case { Meta: ConsoleKey.DownArrow }:
                ClearCursor();
                _selectedOption = (_selectedOption + 1) & 3;
                PrintCursor();
                break;

            case { Meta: ConsoleKey.UpArrow }:
                ClearCursor();
                _selectedOption = (_selectedOption - 1) & 3;
                PrintCursor();
                break;

            case { Meta: ConsoleKey.Enter }:
                switch (_selectedOption)
                {
                    case 3:
                        return false;
                }
                break;

            case { Input: 't' or 'T' }:
                _selectedOption = 0;
                break;

            case { Input: 'e' or 'E' }:
                _selectedOption = 1;
                break;

            case { Input: 'h' or 'H' }:
                _selectedOption = 2;
                break;

            case { Input: 'q' or 'Q' }:
                _selectedOption = 3;
                return false;
        }
        return true;
    }

    private void ClearCursor()
    {
        _console.SetPos(30, 12 + _selectedOption);
        Console.Write("  ");
    }

    private void InitCursor()
    {
        _console.SetPos(30, 12);
        PrintCursor();
    }

    private void PrintCursor()
    {
        _console.SetPos(30, 12 + _selectedOption);
        Console.Write("->");
    }

    private void Print()
    {
        Console.Clear();
        _console.SetPos(30, 10); Console.Write("== Honeywell Fitness Tracker ==");
        _console.SetPos(30, 12); Console.Write("   [T]oday's exercises");
        _console.SetPos(30, 13); Console.Write("   [E]dit exercises");
        _console.SetPos(30, 14); Console.Write("   [H]elp");
        _console.SetPos(30, 15); Console.Write("   [Q]uit Application");
    }

    private void Reset()
    {
        _selectedOption = 0;
    }
}
