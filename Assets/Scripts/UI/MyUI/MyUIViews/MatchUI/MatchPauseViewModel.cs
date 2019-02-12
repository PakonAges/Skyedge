using myUI;
using Zenject;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    readonly SignalBus _signalBus;

    public MatchPauseView View { get { return IView as MatchPauseView; } }
    public MatchPauseViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack, SignalBus signalBus) : base(prefabProvider, uIViewModelsStack)
    {
        _signalBus = signalBus;
    }

    public void RestartMatch()
    {
        _signalBus.Fire<LevelRestartSignal>();
        Close();
    }

    public void ExitToTheMap()
    {
        _signalBus.Fire<ExitMatchSignal>();
    }
}