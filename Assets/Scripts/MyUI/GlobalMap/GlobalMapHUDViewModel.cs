using myUI;

public class GlobalMapHUDViewModel : MyUIViewModel<GlobalMapHUDViewModel>
{
    public GlobalMapHUDView View { get { return MyView as GlobalMapHUDView; } }
    private readonly ICoreSceneController _coreSceneController;

    public GlobalMapHUDViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack, ICoreSceneController coreSceneController) : base(prefabProvider, uIViewModelsStack)
    {
        _coreSceneController = coreSceneController;
    }

    public void LoadMatchScene()
    {
        _coreSceneController.SwitchScene(CoreScene.Match);
    }

    public void LoadLocationScene()
    {
        _coreSceneController.SwitchScene(CoreScene.Location);
    }
}
