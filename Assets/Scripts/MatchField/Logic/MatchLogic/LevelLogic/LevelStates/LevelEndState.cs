using UnityEngine;

public class LevelEndState : ILevelState
{
    public void OnStateEnter()
    {
        Debug.Log("Enter Level End State");
        //win/lose?
        //Show screen
    }

    public void OnStateExit()
    {
        Debug.Log("Level End State Exit");
        //Load map/next level etc.
    }
}
