using myUI;
using Zenject;

public class MatchEndViewModel : MyUIViewModel<MatchEndViewModel>
{
    readonly SignalBus _signalBus;

    public MatchEndView View { get { return IView as MatchEndView; } }
    public MatchEndViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack, SignalBus signalBus) : base(prefabProvider, uIViewModelsStack) { _signalBus = signalBus; }

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
