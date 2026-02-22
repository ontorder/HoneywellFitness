namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed class TodaysExercisesTui(ConsoleWriter cw)
{
    private readonly ConsoleWriter _cw = cw;

    public void Activate()
    {
        Print();
    }

    private void Confirm()
    {
        //float maxWeightKg = float.TryParse(maxWeightKgString, System.Globalization.CultureInfo.InvariantCulture, out maxWeightKg);
        //var add = new CreateExercise(name, muscleGroup, reps: null, maxWeightKg);
        // UNDONE
    }

    private void Print()
    {
        Console.Write("Name: ");
        Console.Write("Muscle group: ");
        Console.Write("Weight (kg): ");
    }
}
