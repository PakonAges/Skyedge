using UnityEngine;
using Zenject;

public class MatchFieldHUD : MonoBehaviour, IUiView
{
    public IUiManager UiManager { get; private set; }
    public UIViewType ViewType { get; private set; }
    public bool DestroyWhenClosed { get; private set; }

    [Inject]
    public void Construct()
    {
        ViewType = UIViewType.MatchFieldHUD;
    }


    public void Init(IUiManager uiManager, UIViewType type, bool DestroyOnClosed)
    {
        UiManager = uiManager;
        //ViewType = type;
        DestroyWhenClosed = DestroyOnClosed;
    }

    public void OpenPauseMenu()
    {
        UiManager.OpenWindowAsync(UIViewType.MatchPauseWindow);
    }

    public void Close()
    {
        throw new System.NotImplementedException();
    }

    public void Show()
    {
        throw new System.NotImplementedException();
    }

    public void OnBackPressed()
    {
        throw new System.NotImplementedException();
    }
}