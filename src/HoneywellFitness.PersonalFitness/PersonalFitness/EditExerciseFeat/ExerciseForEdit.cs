namespace HoneywellFitness.PersonalFitness.EditExerciseFeat;

public sealed class ExerciseForEdit(int exerciseId, string exerciseName, string muscleGroup)
{
    public int ExerciseId = exerciseId;
    public string ExerciseName = exerciseName;
    public string MuscleGroup = muscleGroup;
}
