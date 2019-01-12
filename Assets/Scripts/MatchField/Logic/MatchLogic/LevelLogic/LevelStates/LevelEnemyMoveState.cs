using UnityEngine;

public class LevelEnemyMoveState : ILevelState
{
    readonly MatchLevel _level;

    public LevelEnemyMoveState(MatchLevel level)
    {
        _level = level;
    }

    public void OnStateEnter()
    {
        Debug.Log("Enter Enemy Move State");
        OnStateExit();
        //Decide what to do
        //All enemies move the same turn?
    }

    public void OnStateExit()
    {
        _level.StartNewTurn();

        Debug.Log("Enemy Move State Exit");
        //Back to Player
    }
}
