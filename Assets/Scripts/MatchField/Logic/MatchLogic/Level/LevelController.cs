using UnityEngine;
using Zenject;

public class LevelController : ILevelController
{
    public MatchLevel CurrentLevel { get; private set; }
    readonly ILevelFSM _levelFSM;
    [Inject] readonly MatchEndViewModel _matchEndViewModel = null;
    [Inject] readonly MatchHUDViewModel _hud = null;

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
        CurrentLevel.CurrentTurn = 0;
        _levelFSM.ChangeState(MatchLevelState.PlayerMove);
        _hud.UpdateTurnsCounter(CurrentLevel.TurnsLimit - CurrentLevel.CurrentTurn);
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

        _hud.UpdateTurnsCounter(TurnsLeft);

        if (TurnsLeft > 0)
        {
            Debug.LogFormat("Turns Left: {0}", TurnsLeft);
        }
        else
        {
            _matchEndViewModel.Open();
            Debug.Log("Game Over. No more turns");
        }
    }
}