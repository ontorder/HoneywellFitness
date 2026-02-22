using HoneywellFitness.PersonalFitness.Model;

namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed class TodaysExercisesService(TodayExerciseRepo repo)
{
    private readonly TodayExerciseRepo _repo = repo;

    public ExerciseSummary[] GetTodaysExercises()
    {
        var today = DateTime.Today.DayOfWeek switch
        {
            DayOfWeek.Monday => TrainingDay.Monday,
            DayOfWeek.Tuesday => TrainingDay.Tuesday,
            DayOfWeek.Wednesday => TrainingDay.Wednesday,
            DayOfWeek.Thursday => TrainingDay.Thursday,
            DayOfWeek.Friday => TrainingDay.Friday,
            DayOfWeek.Saturday => TrainingDay.Saturday,
            _ => TrainingDay.Sunday
        };
        var exercises = _repo.GetExerciseSummaryByDay(today);
        return exercises;
    }

    public TodayExerciseItem GetExercise(int exerciseId)
        => _repo.GetExercise(exerciseId);
}
