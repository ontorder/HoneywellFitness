namespace HoneywellFitness.PersonalFitness.MainMenuFeat;

public sealed class MainMenuTui
{
    public void Activate()
    {
        Print();
    }

    public bool HandleNextInput(StdinValue input)
    {
        return true;
    }

    private void Print()
    {
        Console.Clear();
        Console.WriteLine("== Honeywell Fitness Tracker ==");
        Console.WriteLine();
        Console.WriteLine("   [A]dd New Exercise");
        Console.WriteLine("   [V]iew Exercises in Database");
        Console.WriteLine("   [E]dit a Exercise");
        Console.WriteLine("   [Q]uit Application");
    }
}
