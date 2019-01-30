using myUI;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    MatchPauseView _view;
    public MatchPauseView View
    {
        get { return IView as MatchPauseView; }
        set { _view = value; }
    }

    public MatchPauseViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
}
