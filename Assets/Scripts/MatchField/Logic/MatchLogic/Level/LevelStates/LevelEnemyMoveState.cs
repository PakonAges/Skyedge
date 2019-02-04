using UnityEngine;

public class LevelEnemyMoveState : ILevelState
{
    public ILevelController LevelController { get; set; }

    public void OnStateEnter()
    {
        Debug.Log("Enter Enemy Move State");
        //Decide what to do
        //All enemies move the same turn?
    }

    public void OnStateExit()
    {
        Debug.Log("Enemy Move State Exit");
        //Back to Player
    }
}
