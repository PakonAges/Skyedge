using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

public class LevelController : ILevelController, IInitializable, IDisposable
{
    readonly ILevelFSM _levelFSM;
    //readonly SignalBus _signalBus;
    [Inject] readonly MatchEndViewModel _matchEndViewModel = null;
    [Inject] readonly MatchHUDViewModel _hud = null;
    readonly ILevelDataProvider _levelDataProvider;
    public MatchLevel CurrentLevel { get { return _levelDataProvider.MatchLevel; } }

    public LevelController( ILevelFSM levelFSM,
                            //SignalBus signalBus,
                            ILevelDataProvider levelDataProvider)
    {
        _levelFSM = levelFSM;
        //_signalBus = signalBus;
        _levelDataProvider = levelDataProvider;
    }

    public void Initialize()
    {
        _levelFSM.SetupFSM(this);

        //_signalBus.Subscribe<LevelRestartSignal>(ResetLevel);
    }

    public void Dispose()
    {
        //_signalBus.Unsubscribe<LevelRestartSignal>(ResetLevel);
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
        int TurnsLeft = CurrentLevel.TurnsLimit - CurrentLevel.CurrentTurn;
        _hud.UpdateTurnsCounter(TurnsLeft);
        Debug.LogFormat("Restart Level. Turns Left: {0}", CurrentLevel.TurnsLimit);
    }

    public async Task EndOfPlayerMoveAsync()
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
            await _matchEndViewModel.Open();
            Debug.Log("Game Over. No more turns");
        }
    }

}