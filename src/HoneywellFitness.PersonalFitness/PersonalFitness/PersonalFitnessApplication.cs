using HoneywellFitness.PersonalFitness.Storage;
using HoneywellFitness.TextUi;

namespace HoneywellFitness.PersonalFitness;

public sealed class PersonalFitnessApplication
{
    private readonly ConsoleReader _consoleReader = new();
    private readonly ExercisesMemoryStorage _exerciseStorage = new();
    private readonly ExerciseRepositorySeeder _seeder = new();
    private readonly TuiThingy.TerminalUi _tui = new();

    public void ApplicationMessageLoop()
    {
        _consoleReader.Init();
        _tui.Init();

        _exerciseStorage.Seed(_seeder.TempExercises);

        _tui.MainAskChoice();

        _ = _consoleReader.ReadInput();
        _tui.AddExercise();
        _tui.ListExercises();
        _tui.EditExercise();
    }
}
