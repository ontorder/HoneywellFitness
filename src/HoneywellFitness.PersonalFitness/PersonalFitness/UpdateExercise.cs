namespace HoneywellFitness.PersonalFitness;

public sealed class UpdateExercise(string exerciseName, string muscleGroup, IRepetitions reps, float weightKg)
{
    public string ExerciseName = exerciseName;
    public string MuscleGroup = muscleGroup;
    public IRepetitions Reps = reps;
    public float WeightKg = weightKg;
}
