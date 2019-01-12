public class EnemiesController : IEnemiesController
{
    readonly ILevelFSM _levelFSM;

    public EnemiesController(ILevelFSM levelFSM)
    {
        _levelFSM = levelFSM;
    }

    public void MoveAction()
    {
        _levelFSM.ChangeState(MatchLevelState.PlayerMove);
    }
}
