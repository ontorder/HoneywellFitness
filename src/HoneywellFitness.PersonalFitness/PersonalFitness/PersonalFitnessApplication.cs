using HoneywellFitness.PersonalFitness.Storage;

namespace HoneywellFitness.PersonalFitness;

public sealed class PersonalFitnessApplication
{
    private readonly ConsoleReader _consoleReader = new();
    private readonly ExercisesMemoryStorage _exerciseStorage = new();
    private readonly ExerciseRepositorySeeder _seeder = new();

    public void ApplicationMessageLoop()
    {
        _exerciseStorage.Seed(_seeder.TempExercises);
        _consoleReader.Init();

        TuiThingy.TerminalUi tui = new(_exerciseStorage);
        tui.Init();

        StdinValue input;
        do
        {
            input = _consoleReader.ReadInput();
        }
        while (tui.HandleNextInput(input));
    }
}
