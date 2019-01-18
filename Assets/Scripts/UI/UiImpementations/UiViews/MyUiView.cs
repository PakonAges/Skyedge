using UnityEngine;
using Zenject;

public abstract class MyUiView : MonoBehaviour
{
    public bool DestroyWhenClosed { get; private set; }
    //[Tooltip("Disable menus that are under this one in the stack")]
    //public bool DisableMenusUnderneath = true;
    public UIViewType ViewType { get; private set; }

    protected IUiManager _uiManager;

    [Inject]
    public virtual void Construct(IUiManager uIManager)
    {
        _uiManager = uIManager;
        ViewType = UIViewType.Invalid;
        DestroyWhenClosed = false;
    }

    public virtual void Close()
    {
        //if (DestroyWhenClosed)
        //{
        //    _uiManager.CloseWindow(this);
        //}
        //else
        //{
        //    _uiManager.HideAndCacheWindow(this);
        //}
    }

    public virtual void OnBackPressed()
    {
        Close();
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }
}
