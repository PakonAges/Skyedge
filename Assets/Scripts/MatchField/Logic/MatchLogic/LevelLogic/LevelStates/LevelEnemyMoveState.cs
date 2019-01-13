using UnityEngine;

public class LevelEnemyMoveState : ILevelState
{
    public MatchLevel Level { get; set; }

    //Enemies Controller

    public void OnStateEnter()
    {
        Debug.Log("Enter Enemy Move State");
        OnStateExit();
        //Decide what to do
        //All enemies move the same turn?
    }

    public void OnStateExit()
    {
        //Enemies Controller. Move ACtion
        Debug.Log("Enemy Move State Exit");
        //Back to Player
    }
}
