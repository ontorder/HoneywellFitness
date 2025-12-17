namespace HoneywellFitness
{
  internal class Program
  {
    static void Main(string[] args)
    {
      ExercisesManager exerciseManager = new ExercisesManager();
      Console.WriteLine("Honeywell Fitness Tracker.");
      Console.WriteLine("Pick from the following options below. ");
      Console.WriteLine("1. Add New Exercise");
      Console.WriteLine("2. View Exercises in Database");
      Console.WriteLine("0. Quit Application");
      Console.Write("Choice: ");
      bool isValidInput = int.TryParse(Console.ReadLine(), out int choice);

      do
      {
        switch(choice)
        {
          case 1:
            // Add Exercise
            Console.WriteLine("Test Add Exercise.");
            exerciseManager.AddExercise();

            Console.Write("Option: ");
            isValidInput = int.TryParse(Console.ReadLine(), out choice);
            break;

          case 2:
            // Show the list of exercises within the database/list
            Console.WriteLine("Test Show Exercises.");
            exerciseManager.ListExercises();

            Console.WriteLine("Option: ");
            isValidInput = int.TryParse(Console.ReadLine(), out choice);
            break;

          default:
            Console.WriteLine("Invalid input - please choose from the options listed.");
            Console.Write("Option: ");
            isValidInput = int.TryParse(Console.ReadLine(), out choice);
            break;
        }
      } while (choice != 0);
    }
  }
}
