public class LocationHUDViewModel
{
    private readonly ICoreSceneController _coreSceneController;

    public LocationHUDViewModel(ICoreSceneController coreSceneController)
    {
        _coreSceneController = coreSceneController;
    }

    public void LoadLocationScene()
    {
        _coreSceneController.SwitchScene(CoreScene.Location);
    }
}
