using myUI;
using System;
using UnityEngine;
using Zenject;

public class MatchHUDViewModel : MyUIViewModel<MatchHUDViewModel>
{
    public MatchHUDView View { get { return MyView as MatchHUDView; } }

    [Inject] readonly MatchPauseViewModel _pauseWindow = null;
    [Inject] readonly ConfirmExitGameViewModel _exitConfirmWindow = null;


    public async void ShowConfirmToClose()
    {
        try
        {
            await _exitConfirmWindow.Open();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public override void Close()
    {
        ShowConfirmToClose();
        //base.Close();
    }

    public async void ShowPauseView()
    {
        try
        {
            await _pauseWindow.Open();
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }

    public void UpdateTurnsCounter(int turnsLeft)
    {
        var displayString = "Turns left: " + turnsLeft.ToString();
        View.TurnsCounter = displayString;
    }
}
