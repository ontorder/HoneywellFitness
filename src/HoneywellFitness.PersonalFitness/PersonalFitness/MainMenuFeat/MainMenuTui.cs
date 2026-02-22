using HoneywellFitness.TuiThingy;

namespace HoneywellFitness.PersonalFitness.MainMenuFeat;

public sealed class MainMenuTui(ConsoleWriter console, SystemServices system)
{
    private readonly ConsoleWriter _console = console;
    private MenuOptions _selectedOption = MenuOptions.TodaysExercises;
    private readonly SystemServices _system = system;

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
                _selectedOption = (MenuOptions)(((int)_selectedOption + 1) & 3);
                PrintCursor();
                break;

            case { Meta: ConsoleKey.UpArrow }:
                ClearCursor();
                _selectedOption = (MenuOptions)(((int)_selectedOption - 1) & 3);
                PrintCursor();
                break;

            case { Meta: ConsoleKey.Enter }:
                switch (_selectedOption)
                {
                    case MenuOptions.Help: _system.NavigatorSwitchContext(TuiContext.Help); return true;
                    case MenuOptions.EditExercises: _system.NavigatorSwitchContext(TuiContext.ExercisesDb); return true;
                    case MenuOptions.TodaysExercises: _system.NavigatorSwitchContext(TuiContext.TodaysExercises); return true;
                    case MenuOptions.Quit: return false;
                }
                break;

            case { Input: 't' or 'T' }:
                _selectedOption = MenuOptions.TodaysExercises;
                _system.NavigatorSwitchContext(TuiContext.TodaysExercises);
                break;

            case { Input: 'e' or 'E' }:
                _selectedOption = MenuOptions.EditExercises;
                _system.NavigatorSwitchContext(TuiContext.ExercisesDb);
                break;

            case { Input: 'h' or 'H' }:
                _selectedOption = MenuOptions.Help;
                _system.NavigatorSwitchContext(TuiContext.Help);
                return true;

            case { Input: 'q' or 'Q' }:
                _selectedOption = MenuOptions.Quit;
                return false;
        }
        return true;
    }

    private void ClearCursor()
    {
        _console.SetPos(30, 12 + (int)_selectedOption);
        Console.Write("  ");
    }

    private void InitCursor()
    {
        _console.SetPos(30, 12);
        PrintCursor();
    }

    private void PrintCursor()
    {
        _console.SetPos(30, 12 + (int)_selectedOption);
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

    private enum MenuOptions
    {
        TodaysExercises = 0,
        EditExercises = 1,
        Help = 2,
        Quit = 3,
    }
}
