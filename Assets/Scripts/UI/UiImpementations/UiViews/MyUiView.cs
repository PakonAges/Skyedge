using UnityEngine;

public abstract class MyUiView : MonoBehaviour, IUiView
{
    [Tooltip("Destroy the Game Object when menu is closed")]
    public bool DestroyWhenClosed = true;
    [Tooltip("Disable menus that are under this one in the stack")]
    public bool DisableMenusUnderneath = true;

    protected IUiManager _uiManager;
    protected abstract UIViewType _viewType { get; }

    public MyUiView(IUiManager uIManager)
    {
        _uiManager = uIManager;
    }

    public virtual void Open()
    {
        _uiManager.OpenWindowAsync(_viewType);
    }

    public virtual void Close()
    {
        _uiManager.CloseWindow(this);
    }

    public virtual void OnBackPressed()
    {
        Close();
    }
}
