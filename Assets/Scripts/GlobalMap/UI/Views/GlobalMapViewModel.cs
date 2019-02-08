public class GlobalMapViewModel
{
    private readonly ICoreSceneController _coreSceneController;

    public GlobalMapViewModel(ICoreSceneController coreSceneController)
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
