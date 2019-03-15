using myUI;
using Zenject;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel, MatchPauseView>
{
    readonly SignalBus _signalBus;

    public MatchPauseViewModel(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void RestartMatch()
    {
        Close();
        _signalBus.Fire<LevelRestartSignal>();
    }

    public void ExitToTheMap()
    {
        Close();
        _signalBus.Fire<ExitMatchSignal>();
    }
}