namespace HoneywellFitness.PersonalFitness;

internal sealed class ExercisesMemoryRepository
{
    private readonly List<Exercise> _exercises = [];
    private int _autoincId = 0;

    public void AddExercise(CreateExercise newExercise)
        => _exercises.Add(new Exercise(_autoincId++, newExercise.ExerciseName, newExercise.MuscleGroup, newExercise.Reps, newExercise.Sets, newExercise.WeightKg));

    public Exercise[] GetExercises()
        => [.. _exercises];

    public void UpdateExercise(int exerciseId, UpdateExercise update)
    {
        var found = _exercises.FirstOrDefault( _ => _.ExerciseId == exerciseId);
        if (found == null) return;
        found.ExerciseName = update.ExerciseName;
        found.MuscleGroup = update.MuscleGroup;
        found.Reps = update.Reps;
        found.Sets = update.Sets;
        found.WeightKg = update.WeightKg;
    }
}
