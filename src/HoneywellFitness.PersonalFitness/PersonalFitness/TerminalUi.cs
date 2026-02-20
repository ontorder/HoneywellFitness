namespace HoneywellFitness.PersonalFitness;

internal sealed class TerminalUi
{
    public object MainAskChoice()
    {
        Console.WriteLine("Honeywell Fitness Tracker.");
        Console.WriteLine("Pick from the following options below.");
        Console.WriteLine("Add  | Add New Exercise");
        Console.WriteLine("View | View Exercises in Database");
        Console.WriteLine("Edit | Edit a Exercise");
        Console.WriteLine("Quit | Quit Application");
        Console.Write("Choice: ");
        var userInput = Console.ReadLine()?.Trim();
        if (userInput == null) throw new Exception("TODO");
        var shortcut = char.ToLower(userInput[0]);
        return shortcut switch
        {
            'a' => 1,
            'e' => 2,
            'q' => 3,
            'v' => 4,
            _ => 5
        };
    }

    public void AddExercise()
    {
        Console.Write("Enter a name for a exercise: ");
        var name = Console.ReadLine()!;

        Console.Write("Enter the muscle group: ");
        var muscleGroup = Console.ReadLine()!;

        Console.Write("Enter the maximum weight used (kg): ");
        var maxWeightKgString = Console.ReadLine();
        float maxWeightKg;
        while (false == float.TryParse(maxWeightKgString, System.Globalization.CultureInfo.InvariantCulture, out maxWeightKg))
        {
            Console.WriteLine("Please enter a real number.");
            Console.Write("Enter the maximum weight used (kg): ");
            maxWeightKgString = Console.ReadLine()!.Trim();
        }

        var add = new CreateExercise(name, muscleGroup, reps: 0, sets: 0, maxWeightKg);
        // UNDONE
    }

    public void ListExercises()
    {
        var undone = Array.Empty<ViewExercise>();
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

    public void EditExercise()
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
        var selectedExercise = new Exercise(default, default, default, default, default, default);

        Console.WriteLine($"=== Editing Exercise  ===");
        Console.WriteLine($"=== Exercise Information ===");
        Console.WriteLine($"\tId: {selectedExerciseId}");
        Console.WriteLine($"\tName: {selectedExercise.ExerciseName}");
        Console.WriteLine($"\tMax Weight (kg): {selectedExercise.WeightKg}");
        Console.WriteLine($"\tSets: {selectedExercise.Sets}");
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

        var upd = new UpdateExercise(name, default, default, default, weightKg);
        // UNDONE
    }
}
