namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed record ExerciseSummary(
    int ExerciseId,
    Model.ExerciseImportance Importance,
    string Name);
