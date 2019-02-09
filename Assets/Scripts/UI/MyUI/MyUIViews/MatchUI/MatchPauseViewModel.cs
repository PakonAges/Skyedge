using myUI;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    private readonly ICoreSceneController _coreSceneController;

    public MatchPauseView View { get { return IView as MatchPauseView; } }
    public MatchPauseViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack, ICoreSceneController coreSceneController) : base(prefabProvider, uIViewModelsStack)
    {
        _coreSceneController = coreSceneController;
    }



    public void ExitToTheMap()
    {
        _coreSceneController.SwitchScene(CoreScene.Map);
    }
}