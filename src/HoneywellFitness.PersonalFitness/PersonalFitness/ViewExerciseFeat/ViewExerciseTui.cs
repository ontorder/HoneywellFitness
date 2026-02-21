namespace HoneywellFitness.PersonalFitness.ViewExerciseFeat;

public sealed class ViewExerciseTui
{
    public void Activate()
    {
    }

    private void Print()
    {
        var undone = Array.Empty<ViewExerciseModel>();
        if (undone.Length == 0)
        {
            Console.WriteLine("No exercises exist in the database.");
            return;
        }

        Console.WriteLine("The database contains the following exercises: ");
        foreach (var exercise in undone)
        {
            Console.WriteLine($"Name: {exercise.ExerciseName} | Max Weight (Kg): {exercise.WeightKg}");
        }
    }
}
