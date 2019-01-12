using UnityEngine;

public class LevelPlayerMoveState : ILevelState
{
    public void OnStateEnter()
    {
        Debug.Log("Enter PlayerMove State");
        //Ready To rumble
    }

    public void OnStateExit()
    {
        Debug.Log("PlayerMove State Exit");
        //Time for enemies to move
    }
}
