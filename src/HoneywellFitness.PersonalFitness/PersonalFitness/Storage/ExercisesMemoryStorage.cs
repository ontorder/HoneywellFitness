using HoneywellFitness.PersonalFitness.Model;

namespace HoneywellFitness.PersonalFitness.Storage;

public sealed class ExercisesMemoryStorage
{
    private readonly List<Exercise> _exercises = [];
    private int _autoincId = 0;

    public void AddExercise(CreateExercise newExercise)
        => _exercises.Add(new Exercise(
            _autoincId++,
            newExercise.ExerciseName,
            importance: default,
            muscleGroup: newExercise.MuscleGroup,
            repetitionsMode: default,
            newExercise.Reps,
            newExercise.TrainOnDay,
            wasLastExerciseFinished: false));

    public Exercise[] GetExercises()
        => [.. _exercises];

    public void Seed(Exercise[] seed)
    {
        _exercises.Clear();
        _exercises.AddRange(seed);
    }

    public void UpdateExercise(int exerciseId, UpdateExercise update)
    {
        var found = _exercises.FirstOrDefault(_ => _.ExerciseId == exerciseId);
        if (found == null) return;
        found.ExerciseName = update.ExerciseName;
        found.MuscleGroup = update.MuscleGroup;
        found.Reps = update.Reps;
    }
}
