using myUI;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    public MatchPauseView View { get { return IView as MatchPauseView; } }
    public MatchPauseViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
}