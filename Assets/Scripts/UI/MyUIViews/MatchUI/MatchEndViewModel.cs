using myUI;

public class MatchEndViewModel : MyUIViewModel<MatchEndViewModel>
{
    public MatchEndView View { get { return IView as MatchEndView; } }
    public MatchEndViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }
}
