namespace HoneywellFitness.PersonalFitness;

public sealed class OneRepSetRepetition(int reps, int sets, float weightKg, WeightValueMode weightValueMode) : IRepetitions
{
    public int Reps = reps;
    public int Sets = sets;
    public float WeightKg = weightKg;
    public WeightValueMode WeightValueMode = weightValueMode;
}
