using HoneywellFitness.TuiThingy;

namespace HoneywellFitness.PersonalFitness.TodaysExercisesFeat;

public sealed class TodaysExercisesTui(ConsoleWriter cw, SystemServices system, TodaysExercisesService todaysExercisesService)
{
    private readonly ConsoleWriter _console = cw;
    private int _selected = 0;
    private readonly SystemServices _system = system;
    private readonly TodaysExercisesService _todaysExercisesService = todaysExercisesService;

    public void Activate()
    {
        Print();
    }

    public bool HandleNextInput(StdinValue input)
    {
        switch (input)
        {
            case { IsErr: true }:
                break;

            case { Meta: ConsoleKey.Escape }:
                // TODO "are you sure?"
                _system.NavigatorSwitchContext(TuiContext.MainMenu);
                return true;

            case { Meta: ConsoleKey.DownArrow }:
                ++_selected;
                // draw cursor
                break;

            case { Meta: ConsoleKey.UpArrow }:
                --_selected;
                // draw cursor
                break;
        }
        return true;
    }

    private void Confirm()
    {
        // what can i do here, set if exercises was completed?
    }

    private void Print()
    {
        Console.Clear();
        _console.SetPos(10, 1); Console.Write("=== Training session ===");

        var summary = _todaysExercisesService.GetTodaysExercises();
        for (var summaryId = 0; summaryId < summary.Length; ++summaryId)
        {
            _console.SetPos(3, 3 + summaryId);
            Console.Write($"Name: {summary[summaryId].Name} ({(summary[summaryId].Importance == Model.ExerciseImportance.Primary ? 'P' : 'S')})");

            if (summaryId == 0)
            {
                _console.SetPos(2, 3 + summaryId);
                Console.Write(">");
            }
        }

        var selected = summary.Length > 0
            ? _todaysExercisesService.GetExercise(summary[0].ExerciseId)
            : new(string.Empty, "not selected", null!); // TODO don't use null

        _console.SetPos(30, 3); Console.Write("Muscle group: "); Console.Write(selected.MuscleGroup);
        switch (selected.Repetitions)
        {
            case null:
                // TODO empty interface
                break;

            case Model.LoadAndVolumeRepetitions loadAndVolume:
                _console.SetPos(30, 5); Console.Write("Type: load and volume");
                // TODO weight value mode
                _console.SetPos(30, 6); Console.Write($"Load: {loadAndVolume.LoadSets} x {loadAndVolume.LoadReps} @ 8 RPE / {loadAndVolume.LoadWeightKg} kg");
                _console.SetPos(30, 7); Console.Write($"Volume: {loadAndVolume.VolumeSets} x {loadAndVolume.VolumeReps} @ 8 RPE / {loadAndVolume.VolumeWeightKg} kg");
                break;

            case Model.OneRepSetRepetition oneSetRep:
                _console.SetPos(30, 5); Console.Write("Type: regular SxR");
                // TODO weight value mode
                _console.SetPos(30, 6); Console.Write($"{oneSetRep.Sets} x {oneSetRep.Reps} @ 8 RPE / {oneSetRep.WeightKg} kg");
                break;

            case Model.TimeBasedRepetition time:
                _console.SetPos(30, 5); Console.Write("Exercise based on time");
                _console.SetPos(30, 6); Console.Write("Duration: "); Console.Write(time.Duration);
                break;
        }

    }
}
