namespace HoneywellFitness.Utils;

internal sealed class InputValidator
{
    public static int IsInputValid(string input)
    {
        int result;
        while (!int.TryParse(input, out result))
        {
            Console.WriteLine("An incorrect value has been entered. Please recheck the value and try again.");
            Console.Write("Option: ");
            input = Console.ReadLine();
        }
        return result;
    }
}
