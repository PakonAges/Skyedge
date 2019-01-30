using myUI;

public class MatchEndViewModel : MyUIViewModel<MatchEndViewModel>
{
    MatchEndView _view;
    public MatchEndView View
    {
        get { return IView as MatchEndView; }
        set { _view = value; }
    }

    public MatchEndViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
}
