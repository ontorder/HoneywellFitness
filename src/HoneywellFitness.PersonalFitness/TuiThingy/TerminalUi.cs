namespace HoneywellFitness.TuiThingy;

public sealed class TerminalUi
{
    private TuiContext _currentContext = TuiContext.MainMenu;
    private readonly PersonalFitness.EditExerciseFeat.EditExercisesService _editExercisesService;
    private readonly PersonalFitness.EditExerciseFeat.EditExerciseTui _editExerciseTui;
    private readonly PersonalFitness.Storage.ExercisesMemoryStorage _exerciseStorage;
    private readonly PersonalFitness.HelpFeat.HelpTui _helpTui;
    private readonly PersonalFitness.MainMenuFeat.MainMenuTui _mainMenuTui;
    private readonly SystemServices _system;
    private readonly PersonalFitness.TodaysExercisesFeat.TodaysExercisesService _todaysExercisesService;
    private readonly PersonalFitness.TodaysExercisesFeat.TodaysExercisesTui _todaysExercisesTui;
    private readonly PersonalFitness.TodaysExercisesFeat.TodayExerciseRepo _todayExerciseRepo;

    public TerminalUi(PersonalFitness.Storage.ExercisesMemoryStorage exerciseStorage, ConsoleWriter cw)
    {
        _exerciseStorage = exerciseStorage;
        _system = new SystemServices(SwitchContext);
        _todayExerciseRepo = new PersonalFitness.TodaysExercisesFeat.TodayExerciseRepo(_exerciseStorage);
        _todaysExercisesService = new PersonalFitness.TodaysExercisesFeat.TodaysExercisesService(_todayExerciseRepo);
        _editExercisesService = new PersonalFitness.EditExerciseFeat.EditExercisesService();
        _mainMenuTui = new PersonalFitness.MainMenuFeat.MainMenuTui(cw, _system);
        _editExerciseTui = new PersonalFitness.EditExerciseFeat.EditExerciseTui(cw, _system, _editExercisesService);
        _helpTui = new PersonalFitness.HelpFeat.HelpTui(cw, _system);
        _todaysExercisesTui = new PersonalFitness.TodaysExercisesFeat.TodaysExercisesTui(cw, _system, _todaysExercisesService);
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (_currentContext)
        {
            case TuiContext.ExercisesDb:
                if (false == _editExerciseTui.HandleNextInput(input))
                    return false;
                break;

            case TuiContext.Help:
                if (false == _helpTui.HandleNextInput(input))
                    return false;
                break;

            case TuiContext.MainMenu:
                if (false == _mainMenuTui.HandleNextInput(input))
                    return false;
                break;

            case TuiContext.TodaysExercises:
                if (false == _todaysExercisesTui.HandleNextInput(input))
                    return false;
                break;
        }
        return true;
    }

    public void Init()
    {
        _mainMenuTui.Activate();
    }

    private void SwitchContext(TuiContext newContext)
    {
        _currentContext = newContext;
        switch (newContext)
        {
            case TuiContext.ExercisesDb: _editExerciseTui.Activate(); break;
            case TuiContext.Help: _helpTui.Activate(); break;
            case TuiContext.MainMenu: _mainMenuTui.Activate(); break;
            case TuiContext.TodaysExercises: _todaysExercisesTui.Activate(); break;
        }
    }
}
