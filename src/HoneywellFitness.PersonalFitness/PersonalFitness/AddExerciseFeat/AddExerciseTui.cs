namespace HoneywellFitness.PersonalFitness.AddExerciseFeat;

public sealed class AddExerciseTui
{
    public void Activate()
    {
        Print();
    }

    private void Confirm()
    {

        //float maxWeightKg = float.TryParse(maxWeightKgString, System.Globalization.CultureInfo.InvariantCulture, out maxWeightKg);
        //var add = new CreateExercise(name, muscleGroup, reps: null, maxWeightKg);
        // UNDONE
    }

    private void Print()
    {
        Console.Write("Name: ");
        Console.Write("Muscle group: ");
        Console.Write("Weight (kg): ");

    }
}
