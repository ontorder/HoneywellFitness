namespace HoneywellFitness.PersonalFitness.EditExerciseFeat;

public sealed class EditExerciseTui(ConsoleWriter console)
{
    private readonly ConsoleWriter _console = console;

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
                break;
        }
        return true;
    }

    private void Print()
    {
        Console.Clear();
        _console.SetPos(30, 10); Console.Write("=== Exercises Database ===");
        _console.SetPos(2, 2); Console.Write("Id: ");
        _console.SetPos(2, 3); Console.Write("Name: ");
        _console.SetPos(2, 4); Console.Write("Muscle group: ");
        _console.SetPos(2, 5); Console.Write("Trained on: ");
        _console.SetPos(2, 6); Console.Write("Importance: ");
        _console.SetPos(2, 7); Console.Write("Was completed: ");
    }

    private void Submit()
    {
        //var upd = new UpdateExercise(name, default, default, weightKg);
    }
}
