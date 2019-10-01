using UnityEngine;

public class LevelPlayerMoveState : ILevelState
{
    public ILevelController LevelController { get; set; }

    public void OnStateEnter()
    {
        Debug.LogFormat("Enter PlayerMove State. Curent turn: {0}", LevelController.CurrentLevel.CurrentTurn);
        //Ready To rumble
    }

    public void OnStateExit()
    {
        Debug.Log("PlayerMove State Exit");
        LevelController.EndOfPlayerMoveAsync();
        //Time for enemies to move
    }
}
