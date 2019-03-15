using myUI;

public class GlobalMapHUDViewModel : MyUIViewModel<GlobalMapHUDViewModel>
{
    public GlobalMapHUDView View { get { return MyView as GlobalMapHUDView; } }
    private readonly ICoreSceneController _coreSceneController;

    public GlobalMapHUDViewModel( ICoreSceneController coreSceneController)
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
