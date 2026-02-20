namespace HoneywellFitness.PersonalFitness;

public sealed class Exercise(int exerciseId, string exerciseName, string muscleGroup, int reps, int sets, float weightKg)
{
    public int ExerciseId = exerciseId;
    public string ExerciseName = exerciseName;
    public string MuscleGroup = muscleGroup;
    public int Reps = reps;
    public int Sets = sets;
    public float WeightKg = weightKg;
}
