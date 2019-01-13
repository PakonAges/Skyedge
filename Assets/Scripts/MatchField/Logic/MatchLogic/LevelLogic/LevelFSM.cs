using UnityEngine;
using Zenject;

public class LevelFSM : ILevelFSM, IInitializable
{
    public ILevelState CurrentState{ get; set; }
    MatchLevel _level;

    ILevelState _init;
    ILevelState _playerMove;
    ILevelState _enemyMove;
    ILevelState _levelEnd;
    ILevelState _pause;

    public LevelFSM()
    {

    }

    public void Initialize()
    {
        _init = new LevelInitState();
        _playerMove = new LevelPlayerMoveState();
        _enemyMove = new LevelEnemyMoveState();
        _levelEnd = new LevelEndState();
        _pause = new LevelPauseState();
    }

    public void SetupFSM(MatchLevel level)
    {
        _level = level;
        _init.Level = _level;
        _playerMove.Level = _level;
        _enemyMove.Level = _level;
        _levelEnd.Level = _level;
        _pause.Level = _level;

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