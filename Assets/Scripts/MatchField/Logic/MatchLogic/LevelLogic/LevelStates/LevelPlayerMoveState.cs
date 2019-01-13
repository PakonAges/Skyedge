using UnityEngine;

public class LevelPlayerMoveState : ILevelState
{
    public MatchLevel Level { get; set; }

    public void OnStateEnter()
    {
        Debug.LogFormat("Enter PlayerMove State. Curent turn: {0}",Level.CurrentTurn);
        //Ready To rumble
    }

    public void OnStateExit()
    {
        Debug.Log("PlayerMove State Exit");
        Level.EndOfPlayerMove();
        //Time for enemies to move
    }
}
