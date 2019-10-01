using UnityEngine;

public class EnemiesController : IEnemiesController
{
    readonly ILevelFSM _levelFSM;

    public EnemiesController(ILevelFSM levelFSM)
    {
        _levelFSM = levelFSM;
    }

    public void StartMove()
    {
        _levelFSM.ChangeState(MatchLevelState.EnemyMove);
        Debug.Log("All enemies do their Evil Stuff");
        EndOfEnemiesMove();
    }

    void EndOfEnemiesMove()
    {
        _levelFSM.ChangeState(MatchLevelState.PlayerMove);
    }
}
