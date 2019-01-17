using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MatchSceneUiManager : IUiManager
{
    readonly IUiPrefabProvider _prefabProvider;
    readonly Stack<IUiView> _menuStack = new Stack<IUiView>();
    readonly Dictionary<UIViewType, IUiView> _cachedMenus = new Dictionary<UIViewType, IUiView>();

    public MatchSceneUiManager (IUiPrefabProvider uiPrefabProvider)
    {
        _prefabProvider = uiPrefabProvider;
    }

    public async Task OpenWindowAsync(UIViewType window)
    {
        //De-activate top View
        //if (_menuStack.Count > 0)
        //{
        //    _menuStack.Peek().Close();
        //}

        if (_cachedMenus.ContainsKey(window))
        {
            _cachedMenus[window].Show();
            _menuStack.Push(_cachedMenus[window]);
            _cachedMenus.Remove(window);

        }
        else
        {
            //add proper Try catch
            GameObject WindowPrefab = await _prefabProvider.GetViewResourceAsync(window);
            GameObject.Instantiate(WindowPrefab);
            _menuStack.Push(WindowPrefab.GetComponent<IUiView>());
        }
    }

    public void CloseWindow(IUiView window)
    {
        //var topView = _menuStack.Pop();
        //Destroy(topView.gameObject);

        //Re-activate top View
        if (_menuStack.Count > 0)
        {
            _menuStack.Peek().Show();
        }
    }

    public void HideAndCacheWindow(IUiView window)
    {
        if (_cachedMenus.ContainsKey(window.ViewType))
        {
            Debug.LogErrorFormat("Trying to hide and Cache View, byt Already cached this: {0}", window);
        }
        else
        {
            _cachedMenus.Add(window.ViewType, window);
            window.Close();
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
