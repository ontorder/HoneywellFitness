namespace HoneywellFitness;

internal sealed class Exercises
{
    public string Name { get; set; }
    public float MaxWeightKG { get; set; }
    public int MaxSets { get; set; }
    public int MaxReps { get; set; }
    public string TargetArea { get; set; }
    public string MuscleGroup { get; set; }

    public Exercises(string name, float maxWeightKG, string targetArea)
    {
        Name = name;
        MaxWeightKG = maxWeightKG;
        TargetArea = targetArea;
    }
}
