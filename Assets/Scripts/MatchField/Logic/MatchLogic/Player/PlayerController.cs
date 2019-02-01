public class PlayerController : IPlayerController
{
    readonly ILevelFSM _levelFSM;
    readonly IEnemiesController _enemiesController;

    public PlayerController (   ILevelFSM levelFSM,
                                IEnemiesController enemiesController)
    {
        _levelFSM = levelFSM;
        _enemiesController = enemiesController;
    }

    public void MoveAction()
    {
        //Do Hero Stuff
        SwithToEnemiesMove();
    }

    void SwithToEnemiesMove()
    {
        _enemiesController.StartMove();
    }
}
