namespace HoneywellFitness.TuiThingy;

public sealed class SystemServices(Action<TuiContext> switchContext)
{
    public Action<TuiContext> NavigatorSwitchContext = switchContext;
}
