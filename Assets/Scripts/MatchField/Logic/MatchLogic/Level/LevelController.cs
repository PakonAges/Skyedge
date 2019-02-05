using UnityEngine;

public class LevelController : ILevelController
{
    public MatchLevel CurrentLevel { get; private set; }
    readonly ILevelFSM _levelFSM;
    //MatchEndViewModel matchEndViewModel;

    public LevelController(ILevelFSM levelFSM)
    {
        _levelFSM = levelFSM;
    }

    public void InitLevel(MatchLevel level)
    {
        CurrentLevel = level;
        _levelFSM.SetupFSM(this);
    }

    public void StartMatch()
    {
        _levelFSM.ChangeState(MatchLevelState.PlayerMove);
    }

    public void ResetLevel()
    {
        CurrentLevel.CurrentTurn = 0;
        Debug.LogFormat("Restart Level. Turns Left: {0}", CurrentLevel.TurnsLimit);
    }

    public void EndOfPlayerMove()
    {
        CurrentLevel.CurrentTurn++;
        int TurnsLeft = CurrentLevel.TurnsLimit - CurrentLevel.CurrentTurn;

        if (TurnsLeft > 0)
        {
            Debug.LogFormat("Turns Left: {0}", TurnsLeft);
        }
        else
        {
            Debug.Log("Game Over. No more turns");
        }
    }
}