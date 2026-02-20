using HoneywellFitness.Utils;

namespace HoneywellFitness.PersonalFitness;

internal sealed class Program
{
    static void Main()
    {
        ExercisesManager exerciseManager = new();
        Console.WriteLine("Honeywell Fitness Tracker.");
        Console.WriteLine("Pick from the following options below. ");
        Console.WriteLine("1. Add New Exercise");
        Console.WriteLine("2. View Exercises in Database");
        Console.WriteLine("3. Edit a Exercise");
        Console.WriteLine("0. Quit Application");
        Console.Write("Choice: ");
        string userInput = Console.ReadLine();
        int choice = InputValidator.IsInputValid(userInput);

        do
        {
            switch (choice)
            {
                case 1:
                    // Add Exercise
                    exerciseManager.AddExercise();

                    Console.Write("Option: ");
                    userInput = Console.ReadLine();
                    choice = InputValidator.IsInputValid(userInput);
                    break;

                case 2:
                    // Show the list of exercises within the database/list
                    exerciseManager.ListExercises();

                    Console.Write("Option: ");
                    userInput = Console.ReadLine();
                    choice = InputValidator.IsInputValid(userInput);
                    break;

                case 3:
                    exerciseManager.EditExercise();

                    Console.Write("Option: ");
                    userInput = Console.ReadLine();
                    choice = InputValidator.IsInputValid(userInput);
                    break;

                default:
                    Console.WriteLine("Invalid input - please choose from the options listed.");
                    Console.Write("Option: ");
                    userInput = Console.ReadLine();
                    choice = InputValidator.IsInputValid(userInput);
                    break;
            }
        }
        while (choice != 0);
    }
}
