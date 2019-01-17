using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MatchSceneUiManager : IUiManager
{
    readonly IUiPrefabProvider _prefabProvider;
    readonly Stack<IWindow> _menuStack = new Stack<IWindow>();

    public MatchSceneUiManager (IUiPrefabProvider uiPrefabProvider)
    {
        _prefabProvider = uiPrefabProvider;
    }

    public async Task OpenWindowAsync(UIViewType window)
    {
        GameObject WindowPrefab = await _prefabProvider.GetViewResourceAsync(window);
        GameObject.Instantiate(WindowPrefab);
        //Instantiate(WindowPrefab);

        //CHeck if window is already created but disabled?
        //Or in the Stack?

        //De-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Hide();
        }

        _menuStack.Push(WindowPrefab.GetComponent<IWindow>());
    }

    public void CloseWindow(IWindow window)
    {
        //var topView = _menuStack.Pop();
        //Destroy(topView.gameObject);

        //Re-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Show();
        }
    }

    public void CloseTopWindow()
    {
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().OnBackPressed();
        }
        else
        {
            Debug.LogError("There are no Active Windows to close");
        }
    }

    public void CloseAll()
    {
        throw new System.NotImplementedException();
    }
}
