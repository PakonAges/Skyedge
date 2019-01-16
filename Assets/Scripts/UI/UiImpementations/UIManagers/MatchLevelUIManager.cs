using System;
using System.Collections.Generic;
using UnityEngine;

public class MatchLevelUIManager : IUiManager
{
    readonly Stack<IWindow> _menuStack = new Stack<IWindow>();

    public void OpenWindow(IWindow window)
    {
        GameObject WindowPrefab = GetPrefab(window);
        //Instantiate(WindowPrefab);

        //CHeck if window is already created but disabled?
        //Or in the Stack?

        //De-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Hide();
        }

        _menuStack.Push(window);
    }

    private GameObject GetPrefab(IWindow window)
    {
        //Get prefab based on name of Window?
        return null;
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
