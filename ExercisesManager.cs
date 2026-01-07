namespace HoneywellFitness
{
  internal class ExercisesManager
  { 
    private readonly List<Exercises> _exercises = new List<Exercises>();

    public void AddExercise()
    {
      Console.Write("Enter a name for a exercise: ");
      string name = Console.ReadLine();

      Console.Write("Enter the maximum weight used (kg): ");
      string maxWeightKgString = Console.ReadLine();
      int maxWeightKg = 0;
      while (!int.TryParse(maxWeightKgString, out maxWeightKg))
      {
        Console.WriteLine("Error - Invalid Input! Input must be a whole number.");
        Console.Write("Enter the maximum weight used (kg): ");
        maxWeightKgString = Console.ReadLine();
      }

      Console.Write("Enter the target area (Arms, Chest, Legs, etc): ");
      string targetArea = Console.ReadLine();

      _exercises.Add(new Exercises(name, maxWeightKg, targetArea));
    }

    public void ListExercises()
    {
      if(_exercises.Count > 0)
      {
        Console.WriteLine("The database contains the following exercises: ");
        foreach (var exercise in _exercises)
        {
          Console.WriteLine($"Name: {exercise.Name} | Max Weight (Kg): {exercise.MaxWeightKG} | Target Area: {exercise.TargetArea}.");
        }
      }
      else
        Console.WriteLine("No exercises exist in the database.");
    }
  }
}
