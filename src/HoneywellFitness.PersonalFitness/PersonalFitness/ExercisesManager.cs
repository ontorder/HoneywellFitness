namespace HoneywellFitness.PersonalFitness;

internal sealed class ExercisesManager
{
    private readonly List<Exercises> _exercises = [];

    public void AddExercise()
    {
        Console.Write("Enter a name for a exercise: ");
        string name = Console.ReadLine();

        Console.Write("Enter the maximum weight used (kg): ");
        string maxWeightKgString = Console.ReadLine();
        float maxWeightKg;
        while (!float.TryParse(maxWeightKgString, out maxWeightKg))
        {
            Console.WriteLine("Error - Invalid Input! Input must be a whole number.");
            Console.Write("Enter the maximum weight used (kg): ");
            maxWeightKgString = Console.ReadLine();
        }

        Console.Write("Enter the target area (Arms, Chest, Legs, etc): ");
        string targetArea = Console.ReadLine();

        _exercises.Add(new Exercises { Exercise = name, MaxWeightKg = maxWeightKg, TargetArea = targetArea });
    }

    public void ListExercises()
    {
        if (_exercises.Count > 0)
        {
            Console.WriteLine("The database contains the following exercises: ");
            foreach (var exercise in _exercises)
            {
                Console.WriteLine($"Name: {exercise.Exercise} | Max Weight (Kg): {exercise.MaxWeightKg} | Target Area: {exercise.TargetArea}.");
            }
        }
        else
            Console.WriteLine("No exercises exist in the database.");
    }

    public void EditExercise()
    {
        if (_exercises.Count == 0)
        {
            Console.WriteLine("No exercises exist in the database to be edited.");
            return;
        }

        int count = 0;
        foreach (var exercise in _exercises)
        {
            Console.WriteLine($"[Index Num: {count}]. Name: {exercise.Exercise} | Max Weight (Kg): {exercise.MaxWeightKg} | Target Area: {exercise.TargetArea}.");
            count++;
        }

        Console.Write("Enter the index number of which exercise you'd like to edit: ");
        string indexNumStr = Console.ReadLine();
        int indexNum;
        while (!int.TryParse(indexNumStr, out indexNum) || indexNum >= _exercises.Count || indexNum < 0)
        {
            Console.WriteLine("Invalid Index Number! Please enter a valid Index Number!");
            Console.Write("Enter the Index Number: ");
            indexNumStr = Console.ReadLine();
        }

        Console.WriteLine($"=== Editing Exercise  ===");
        Console.WriteLine($"=== Exercise Information ===");
        Console.WriteLine($"\tIndex Number: {indexNum}");
        Console.WriteLine($"\tName: {_exercises[indexNum].Exercise}");
        Console.WriteLine($"\tMax Weight (kg): {_exercises[indexNum].MaxWeightKg}");
        Console.WriteLine($"\tTarget Area: {_exercises[indexNum].TargetArea}");

        Console.Write("Enter a name for a exercise: ");
        string name = Console.ReadLine();
        _exercises[indexNum].Exercise = name;

        Console.Write("Enter the maximum weight used (kg): ");
        string maxWeightKgString = Console.ReadLine();
        float maxWeightKg;
        while (!float.TryParse(maxWeightKgString, out maxWeightKg))
        {
            Console.WriteLine("Error - Invalid Input! Please enter a valid number.");
            Console.Write("Enter the maximum weight used (kg): ");
            maxWeightKgString = Console.ReadLine();
        }
        _exercises[indexNum].MaxWeightKg = maxWeightKg;

        Console.Write("Enter the target area (Arms, Chest, Legs, etc): ");
        string targetArea = Console.ReadLine();
        _exercises[indexNum].TargetArea = targetArea;
    }
}
