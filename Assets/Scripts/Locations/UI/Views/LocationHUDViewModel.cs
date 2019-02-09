public class LocationHUDViewModel
{
    private readonly ICoreSceneController _coreSceneController;

    public LocationHUDViewModel(ICoreSceneController coreSceneController)
    {
        _coreSceneController = coreSceneController;
    }

    public void LoadMapScene()
    {
        _coreSceneController.SwitchScene(CoreScene.Map);
    }
}
