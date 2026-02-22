namespace HoneywellFitness.PersonalFitness.Model;

public sealed class Exercise(
    int exerciseId,
    string exerciseName,
    ExerciseImportance importance,
    string muscleGroup,
    RepetitionsMode repetitionsMode,
    IRepetitions reps,
    TrainingDay trainOnDay,
    bool wasLastExerciseFinished)
{
    public int ExerciseId = exerciseId;
    public string ExerciseName = exerciseName;
    public ExerciseImportance Importance = importance;
    public string MuscleGroup = muscleGroup;
    public RepetitionsMode RepetitionsMode = repetitionsMode;
    public IRepetitions Reps = reps;
    public TrainingDay TrainOnDay = trainOnDay;
    public bool WasLastExerciseFinished = wasLastExerciseFinished;
}
