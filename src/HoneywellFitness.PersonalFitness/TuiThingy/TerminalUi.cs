namespace HoneywellFitness.TuiThingy;

public sealed class TerminalUi
{
    private object _coords = new();
    private TuiContext _currentContext = TuiContext.MainMenu;
    private readonly PersonalFitness.Storage.ExercisesMemoryStorage _exerciseStorage;
    private readonly PersonalFitness.MainMenuFeat.MainMenuTui _mainMenu;

    public TerminalUi(PersonalFitness.Storage.ExercisesMemoryStorage exerciseStorage)
    {
        _exerciseStorage = exerciseStorage;
        _mainMenu = new PersonalFitness.MainMenuFeat.MainMenuTui();
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (_currentContext)
        {
            case TuiContext.MainMenu:
                if (false == _mainMenu.HandleNextInput(input))
                    return false;
                break;
        }
        return true;
    }

    public void Init()
    {
        _mainMenu.Activate();
    }

    private void AddExercise()
    {
    }

    private void EditExercise()
    {

    }

    private void ListExercises()
    {
    }

    private void MainAskChoice()
    {

    }

    private enum TuiContext
    {
        MainMenu,
        AddExercise,
        EditExercise,
        ListExercises
    }
}
