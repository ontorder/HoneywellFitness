namespace HoneywellFitness.PersonalFitness.Model;

public sealed class TimeBasedRepetition(TimeSpan duration) : IRepetitions
{
    public readonly TimeSpan Duration = duration;
}
