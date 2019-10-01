using UnityEngine;

public class LevelFSM : ILevelFSM
{
    public ILevelState CurrentState{ get; private set; }
    ILevelController _levelController;

    ILevelState _init;
    ILevelState _playerMove;
    ILevelState _enemyMove;
    ILevelState _levelEnd;
    ILevelState _pause;

    public LevelFSM()
    {
        _init = new LevelInitState();
        _playerMove = new LevelPlayerMoveState();
        _enemyMove = new LevelEnemyMoveState();
        _levelEnd = new LevelEndState();
        _pause = new LevelPauseState();
    }

    public void SetupFSM(ILevelController levelController)
    {
        _levelController = levelController;
        _init.LevelController = _levelController;
        _playerMove.LevelController = _levelController;
        _enemyMove.LevelController = _levelController;
        _levelEnd.LevelController = _levelController;
        _pause.LevelController = _levelController;

        CurrentState = _init;
        CurrentState.OnStateEnter();
    }

    public void ChangeState(MatchLevelState newState)
    {
        CurrentState.OnStateExit();
        CurrentState = GetState(newState);
        CurrentState.OnStateEnter();
    }
    
    /// <summary>
    /// Mapping
    /// </summary>
    /// <param name="state"></param>
    /// <returns></returns>
    ILevelState GetState(MatchLevelState state)
    {
        switch (state)
        {
            case MatchLevelState.Unknown:
            Debug.LogError("Trying to get unknown State");
            return null;
            
            case MatchLevelState.LevelInit:
            return _init;
            
            case MatchLevelState.PlayerMove:
            return _playerMove;
            
            case MatchLevelState.EnemyMove:
            return _enemyMove;
            
            case MatchLevelState.LevelEnd:
            return _levelEnd;

            case MatchLevelState.Pause:
            return _pause;

            default:
            Debug.LogError("Trying to get unknown State");
            return null;
        }
    }


}