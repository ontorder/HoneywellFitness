using HoneywellFitness.PersonalFitness;

namespace HoneywellFitness;

internal sealed class Program
{
    static void Main()
    {
        var app = new PersonalFitnessApplication();
        app.ApplicationMessageLoop();
    }
}
