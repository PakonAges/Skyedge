using myUI;
using System;
using Zenject;

public class MyKeyboardInputProcessor : IInitializable, IDisposable
{
    readonly NewInputManager _newInputManager;
    readonly IFieldSceneController _fieldSceneController;
    readonly IMyUIController _UIController;

    public MyKeyboardInputProcessor(  NewInputManager inputManager,
                                    IFieldSceneController fieldSceneController,
                                    IMyUIController myUIController)
    {
        _newInputManager = inputManager;
        _fieldSceneController = fieldSceneController;
        _UIController = myUIController;
    }

    public void Initialize()
    {
        _newInputManager.Enable();
        _newInputManager.MatchScene.GenreateMap.performed += ctx => StartMatch();
        _newInputManager.MatchScene.Back.performed += ctx => BackPressed();
    }

    public void Dispose()
    {
        _newInputManager.Disable();
    }

    void StartMatch()
    {
        _fieldSceneController.StartMatchAsync();
        _UIController.ShowHUD();
    }

    void BackPressed()
    {
        _UIController.BackPressed();
    }

}
