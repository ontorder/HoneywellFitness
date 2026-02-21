using HoneywellFitness.PersonalFitness.Storage;

namespace HoneywellFitness.PersonalFitness;

public sealed class PersonalFitnessApplication
{
    private readonly ConsoleReader _consoleReader = new();
    private readonly ConsoleWriter _consoleWriter = new();
    private readonly ExercisesMemoryStorage _exerciseStorage = new();
    private readonly ExerciseRepositorySeeder _seeder = new();

    public void ApplicationMessageLoop()
    {
        _exerciseStorage.Seed(_seeder.TempExercises);
        _consoleReader.Init();
        _consoleWriter.Init(_consoleReader.GetWidth(), _consoleReader.GetHeight());

        TuiThingy.TerminalUi tui = new(_exerciseStorage, _consoleWriter);
        tui.Init();

        StdinValue input;
        do
        {
            input = _consoleReader.ReadInput();
        }
        while (tui.HandleNextInput(input));
    }
}
