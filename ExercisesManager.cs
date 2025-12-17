namespace HoneywellFitness
{
  internal class ExercisesManager
  {
    List<Exercises> exercises = new List<Exercises>();

    public void AddExercise()
    {
      Console.Write("Enter a name for a exercise: ");
      string name = Console.ReadLine();

      exercises.Add(new Exercises(name));
    }

    public void ListExercises()
    {
      foreach(var exercise in exercises)
      {
        Console.WriteLine("The database contains the following exercises: ");
        Console.WriteLine(exercise.Name);
      }
    }
  }
}
