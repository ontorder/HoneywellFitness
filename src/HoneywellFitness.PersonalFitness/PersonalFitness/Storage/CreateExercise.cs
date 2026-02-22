using HoneywellFitness.PersonalFitness.Model;

namespace HoneywellFitness.PersonalFitness.Storage;

public sealed class CreateExercise(string exerciseName, string muscleGroup, IRepetitions reps, TrainingDay day, float weightKg)
{
    public string ExerciseName = exerciseName;
    public string MuscleGroup = muscleGroup;
    public IRepetitions Reps = reps;
    public TrainingDay TrainOnDay = day;
    public float WeightKg = weightKg;
}
