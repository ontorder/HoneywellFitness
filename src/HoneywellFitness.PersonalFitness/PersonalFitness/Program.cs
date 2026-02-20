namespace HoneywellFitness.PersonalFitness;

internal sealed class Program
{
    static void Main()
    {
        var app = new PersonalFitnessApplication();
        app.WaitUntilQuit();
    }
}
