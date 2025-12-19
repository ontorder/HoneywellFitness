namespace HoneywellFitness
{
  internal class Exercises
  {
    public string Name { get; set; }
    public int MaxWeightKG { get; set; }
    public int MaxSets { get; set; }
    public int MaxReps { get; set; }
    public string TargetArea { get; set; }
    public string MuscleGroup {  get; set; }

    public Exercises(string name, int maxWeightKG, string targetArea)
    {
      Name = name;
      MaxWeightKG = maxWeightKG;
      TargetArea = targetArea;
    }
  }
}
