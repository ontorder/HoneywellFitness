namespace HoneywellFitness.TuiThingy;

public sealed class TerminalUi
{
    private TuiContext _currentContext = TuiContext.MainMenu;
    private readonly PersonalFitness.EditExerciseFeat.EditExerciseTui _editExerciseTui;
    private readonly PersonalFitness.Storage.ExercisesMemoryStorage _exerciseStorage;
    private readonly PersonalFitness.HelpFeat.HelpTui _helpTui;
    private readonly PersonalFitness.MainMenuFeat.MainMenuTui _mainMenuTui;
    private readonly PersonalFitness.TodaysExercisesFeat.TodaysExercisesTui _todaysExercisesTui;

    public TerminalUi(PersonalFitness.Storage.ExercisesMemoryStorage exerciseStorage, ConsoleWriter cw)
    {
        _exerciseStorage = exerciseStorage;
        _mainMenuTui = new PersonalFitness.MainMenuFeat.MainMenuTui(cw);
        _editExerciseTui = new PersonalFitness.EditExerciseFeat.EditExerciseTui(cw);
        _helpTui = new PersonalFitness.HelpFeat.HelpTui(cw);
        _todaysExercisesTui = new PersonalFitness.TodaysExercisesFeat.TodaysExercisesTui(cw);
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (_currentContext)
        {
            case TuiContext.ExercisesDb:
                break;

            case TuiContext.Help:
                break;

            case TuiContext.MainMenu:
                if (false == _mainMenuTui.HandleNextInput(input))
                    return false;
                break;

            case TuiContext.TodaysExercises:
                break;
        }
        return true;
    }

    public void Init()
    {
        _mainMenuTui.Activate();
    }

    private enum TuiContext
    {
        ExercisesDb,
        Help,
        MainMenu,
        TodaysExercises,
    }
}
