using HoneywellFitness.PersonalFitness.Model;
using HoneywellFitness.PersonalFitness.Storage;

namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed class TodayExerciseRepo(ExercisesMemoryStorage storage)
{
    private readonly ExercisesMemoryStorage _storage = storage;

    public TodayExerciseItem GetExercise(int exerciseId)
    {
        var temp = _storage.Exercises.First(_ => _.ExerciseId == exerciseId);
        return new TodayExerciseItem(
            MuscleGroup: temp.MuscleGroup,
            Name: temp.ExerciseName,
            Repetitions: temp.Reps);
    }

    public ExerciseSummary[] GetExerciseSummaryByDay(TrainingDay day)
    {
        var temp = _storage.Exercises
            .Where(_ => _.TrainOnDay == day)
            .Select(static daily => new ExerciseSummary(
                daily.ExerciseId,
                daily.Importance,
                daily.ExerciseName));
        return [.. temp];
    }
}
