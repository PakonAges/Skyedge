using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MatchSceneUiManager : IUiManager
{
    readonly IUiPrefabProvider _prefabProvider;
    readonly Stack<IUiView> _menuStack = new Stack<IUiView>();

    public MatchSceneUiManager (IUiPrefabProvider uiPrefabProvider)
    {
        _prefabProvider = uiPrefabProvider;
    }

    public async Task OpenWindowAsync(UIViewType window)
    {
        GameObject WindowPrefab = await _prefabProvider.GetViewResourceAsync(window);
        GameObject.Instantiate(WindowPrefab);

        //CHeck if window is already created but disabled in the Stack

        //De-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Close();
        }

        _menuStack.Push(WindowPrefab.GetComponent<IUiView>());
    }

    public void CloseWindow(IUiView window)
    {
        //var topView = _menuStack.Pop();
        //Destroy(topView.gameObject);

        //Re-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Open();
        }
    }

    public void CloseTopWindow()
    {
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Close();
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
