using myUI;

public class MatchPauseViewModel : MyUIViewModel<MatchPauseViewModel>
{
    readonly ICoreSceneController _coreSceneController;
    readonly IMatchController _matchController;

    public MatchPauseView View { get { return IView as MatchPauseView; } }
    public MatchPauseViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack, ICoreSceneController coreSceneController, IMatchController matchController) : base(prefabProvider, uIViewModelsStack)
    {
        _coreSceneController = coreSceneController;
        _matchController = matchController;
    }

    public void RestartMatch()
    {
        _matchController.RestartMatchAsync();
        Close();
    }

    public void ExitToTheMap()
    {
        _coreSceneController.SwitchScene(CoreScene.Map);
    }
}