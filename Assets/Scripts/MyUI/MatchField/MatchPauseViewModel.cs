using myUI;
using Zenject;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    readonly SignalBus _signalBus;

    public MatchPauseView View { get { return MyView as MatchPauseView; } }
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