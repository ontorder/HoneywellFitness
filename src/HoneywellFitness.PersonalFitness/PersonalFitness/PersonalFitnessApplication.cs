using HoneywellFitness.TextUi;

namespace HoneywellFitness.PersonalFitness;

public sealed class PersonalFitnessApplication
{
    private readonly ConsoleReader _consoleReader = new();
    private readonly ExercisesMemoryRepository _exerciseRepo = new();
    private readonly ExerciseRepositorySeeder _seeder = new();
    private readonly TerminalUi _ui = new();

    public PersonalFitnessApplication() { }

    public void WaitUntilQuit()
    {
        _consoleReader.Init();
        _ui.Init();

        var choice = _ui.MainAskChoice();

        do
        {
            switch (choice)
            {
                case 'a':
                    _ui.AddExercise();

                    Console.Write("Option: ");
                    break;

                case 'v':
                    _ui.ListExercises();

                    Console.Write("Option: ");
                    break;

                case 'e':
                    _ui.EditExercise();

                    Console.Write("Option: ");
                    break;

                default:
                    Console.WriteLine("Invalid input - please choose from the options listed.");
                    Console.Write("Option: ");
                    break;
            }
        }
        while (choice != new { TODO = true });
    }
}
