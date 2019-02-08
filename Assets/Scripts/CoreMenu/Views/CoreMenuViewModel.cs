public class CoreMenuViewModel
{
    private readonly ICoreSceneController _coreSceneController;

    public CoreMenuViewModel(ICoreSceneController coreSceneController)
    {
        _coreSceneController = coreSceneController;
    }

    public void LoadMapScene()
    {
        _coreSceneController.SwitchScene(CoreScene.Map);
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
