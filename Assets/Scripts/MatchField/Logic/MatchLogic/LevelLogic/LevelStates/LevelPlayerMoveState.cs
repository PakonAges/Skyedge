using UnityEngine;

public class LevelPlayerMoveState : ILevelState
{
    readonly MatchLevel _level;

    public LevelPlayerMoveState(MatchLevel level)
    {
        _level = level;
    }

    public void OnStateEnter()
    {
        Debug.Log("Enter PlayerMove State");
        //Ready To rumble
    }

    public void OnStateExit()
    {
        Debug.Log("PlayerMove State Exit");
        _level.StartNewTurn();
        //Time for enemies to move
    }
}
