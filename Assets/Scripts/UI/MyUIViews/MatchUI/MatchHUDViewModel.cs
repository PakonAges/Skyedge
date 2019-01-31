﻿using myUI;
using System;
using UnityEngine;
using Zenject;

public class MatchHUDViewModel : MyUIViewModel<MatchHUDViewModel>
{
    public MatchHUDView View { get { return IView as MatchHUDView; } }
    public MatchHUDViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    [Inject] readonly MatchPauseViewModel _pauseWindow = null;
    [Inject] readonly ConfirmExitGameViewModel _exitConfirmWindow = null;


    public async override void ShowConfirmToClose()
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
}
