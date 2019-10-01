using myUI;
using Zenject;

public class MatchEndViewModel : MyUIViewModel<MatchEndViewModel, MatchEndView>
{
    readonly SignalBus _signalBus;

    public MatchEndViewModel(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void RestartLevel()
    {
        _signalBus.Fire<LevelRestartSignal>();
        Close();
    }

    public void ExitToTheMap()
    {
        _signalBus.Fire<ExitMatchSignal>();
    }
}
