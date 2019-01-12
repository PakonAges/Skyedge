public class PlayerController : IPlayerController
{
    readonly ILevelFSM _levelFSM;

    public PlayerController (ILevelFSM levelFSM)
    {
        _levelFSM = levelFSM;
    }

    public void MoveAction()
    {
        _levelFSM.ChangeState(MatchLevelState.EnemyMove);
    }
}
