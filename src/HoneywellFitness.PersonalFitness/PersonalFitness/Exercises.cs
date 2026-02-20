namespace HoneywellFitness.PersonalFitness;

internal sealed class Exercises
{
    public string Exercise { get; set; }
    public int MaxReps { get; set; }
    public int MaxSets { get; set; }
    public float MaxWeightKg { get; set; }
    public string MuscleGroup { get; set; }
    public string TargetArea { get; set; }
}

public sealed class PersonData
{
    public (string Exercise, float WeightKg)[] OneRepMax;

}