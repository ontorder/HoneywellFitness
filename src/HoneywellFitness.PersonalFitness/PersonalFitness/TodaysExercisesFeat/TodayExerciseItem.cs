using HoneywellFitness.PersonalFitness.Model;

namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed record TodayExerciseItem(
    string MuscleGroup,
    string Name,
    IRepetitions Repetitions);
