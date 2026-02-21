using HoneywellFitness.PersonalFitness.Model;

namespace HoneywellFitness.PersonalFitness.Storage;

public sealed class ExerciseRepositorySeeder
{
    public readonly Exercise[] TempExercises = [
        new (1, "biceps curl", ExerciseImportance.Secondary, "biceps", RepetitionsMode.OneFlatSet, new OneRepSetRepetition(3, 12, 20, WeightValueMode.Absolute), true),
        new (2, "chest press", ExerciseImportance.Primary, "pect", RepetitionsMode.LoadAndVolume, new LoadAndVolumeRepetitions(2, 8, 140, 2, 12, 100, WeightValueMode.Absolute), true),
    ];
}
