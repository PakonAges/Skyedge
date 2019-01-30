using myUI;

public class MatchHUDViewModel : MyUIViewModel<MatchHUDViewModel>
{
    MatchHUDView _view;
    public MatchHUDView View
    {
        get { return IView as MatchHUDView; }
        set { _view = value; }
    }

    public MatchHUDViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
}
