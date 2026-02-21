namespace HoneywellFitness.PersonalFitness;

public sealed class LoadAndVolumeRepetitions(int loadReps,
    int loadSets,
    float loadWeightKg,
    int volumeReps,
    int volumeSets,
    float volumeWeightKg,
    WeightValueMode weightValueMode)
    : IRepetitions
{
    public int LoadReps = loadReps;
    public int LoadSets = loadSets;
    public float LoadWeightKg = loadWeightKg;
    public int VolumeReps = volumeReps;
    public int VolumeSets = volumeSets;
    public float VolumeWeightKg = volumeWeightKg;
    public WeightValueMode WeightValueMode = weightValueMode;
}
