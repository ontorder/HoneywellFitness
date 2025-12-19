namespace HoneywellFitness
{
  internal class ExercisesManager
  {
    List<Exercises> exercises = new List<Exercises>();

    public void AddExercise()
    {
      Console.Write("Enter a name for a exercise: ");
      string name = Console.ReadLine();

      Console.Write("Enter the maximum weight used (kg): ");
      int maxWeightKg = int.Parse(Console.ReadLine());

      Console.Write("Enter the target area (Arms, Chest, Legs, etc): ");
      string targetArea = Console.ReadLine();

      exercises.Add(new Exercises(name, maxWeightKg, targetArea));
    }

    public void ListExercises()
    {
      if(exercises.Count > 0)
      {
        Console.WriteLine("The database contains the following exercises: ");
        foreach (var exercise in exercises)
        {
          Console.WriteLine($"Name: {exercise.Name} | Max Weight (Kg): {exercise.MaxWeightKG} | Target Area: {exercise.TargetArea}.");
        }
      }
      else
        Console.WriteLine("No exercises exist in the database.");
    }
  }
}
