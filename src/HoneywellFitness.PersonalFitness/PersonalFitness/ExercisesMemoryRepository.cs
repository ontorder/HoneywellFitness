namespace HoneywellFitness.PersonalFitness;

public sealed class ExercisesMemoryRepository
{
    private readonly List<Exercise> _exercises = [];
    private int _autoincId = 0;

    public void AddExercise(CreateExercise newExercise)
        => _exercises.Add(new Exercise(
            _autoincId++,
            newExercise.ExerciseName,
            importance: default,
            newExercise.MuscleGroup,
            default,
            newExercise.Reps,
            false));

    public Exercise[] GetExercises()
        => [.. _exercises];

    public void UpdateExercise(int exerciseId, UpdateExercise update)
    {
        var found = _exercises.FirstOrDefault(_ => _.ExerciseId == exerciseId);
        if (found == null) return;
        found.ExerciseName = update.ExerciseName;
        found.MuscleGroup = update.MuscleGroup;
        found.Reps = update.Reps;
    }
}
