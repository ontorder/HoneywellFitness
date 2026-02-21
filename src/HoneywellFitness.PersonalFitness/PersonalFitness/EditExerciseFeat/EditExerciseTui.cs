namespace HoneywellFitness.PersonalFitness.EditExerciseFeat;

public sealed class EditExerciseTui
{
    public void Activate()
    {
        Print();
    }

    private void Print()
    {
        var undone = Array.Empty<ExerciseForEdit>();
        if (undone.Length == 0)
        {
            Console.WriteLine("No exercises exist in the database to be edited.");
            return;
        }

        foreach (var exercise in undone)
        {
            Console.WriteLine($"[{exercise.ExerciseId}]. Name: {exercise.ExerciseName} | Muscle group: {exercise.MuscleGroup}");
        }

        Console.Write("Enter the index number of which exercise you'd like to edit: ");
        var idAsString = Console.ReadLine()!;
        int selectedExerciseId;
        while (false == int.TryParse(idAsString, out selectedExerciseId) || selectedExerciseId >= undone.Length || selectedExerciseId < 0)
        {
            Console.WriteLine("Invalid Index Number! Please enter a valid Index Number!");
            Console.Write("Enter the Index Number: ");
            idAsString = Console.ReadLine();
        }

        // UNDONE get from repo
        var selectedExercise = new Model.Exercise(default, default, default, default, default, default, default);

        Console.WriteLine($"=== Editing Exercise  ===");
        Console.WriteLine($"=== Exercise Information ===");
        Console.WriteLine($"\tId: {selectedExerciseId}");
        Console.WriteLine($"\tName: {selectedExercise.ExerciseName}");
        //Console.WriteLine($"\tMax Weight (kg): {selectedExercise.WeightKg}");
        Console.WriteLine($"\tReps: {selectedExercise.Reps}");

        Console.Write("Enter a name for a exercise: ");
        var name = Console.ReadLine()!;

        Console.Write("Enter the weight used (kg): ");
        var weightKgString = Console.ReadLine();
        float weightKg;
        while (!float.TryParse(weightKgString, out weightKg))
        {
            Console.WriteLine("Error - Invalid Input! Please enter a valid number.");
            Console.Write("Enter the maximum weight used (kg): ");
            weightKgString = Console.ReadLine();
        }

        var upd = new UpdateExercise(name, default, default, weightKg);
        // UNDONE
    }
}
