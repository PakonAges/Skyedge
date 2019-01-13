using UnityEngine;

public class LevelInitState : ILevelState
{
    public MatchLevel Level { get; set; }

    public void OnStateEnter()
    {
        Debug.Log("Enter Level Init State");
        //Build Level, Spawn all stuff, etc.
    }

    public void OnStateExit()
    {
        Debug.Log("Level Init State Exit");
        //Enable Input and start the game
    }
}
