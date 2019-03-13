using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;
using myUI;

//Manages High Level application
//Scene Loading State Machine

public class CoreSceneController : ICoreSceneController, IDisposable, ITickable
{
    private CoreScene _currentCoreScene;
    private CoreScene _nextCoreScene;
    private AsyncOperation _resourceUnloadTask;
    private AsyncOperation _sceneLoadTask;
    private enum SceneState
    {
        Reset,
        Preload,
        Load,
        Unload,
        PostLoad,
        Ready,
        Run,
        Count
    };

    private SceneState _sceneState;
    private delegate void UpdateDelegate();
    private UpdateDelegate[] _updateDelegates;
    readonly IMyUIViewModelsStack _uiStack;

    public CoreSceneController(CoreScene sceneToLoad, IMyUIViewModelsStack myUIViewStack)
    {
        _updateDelegates = new UpdateDelegate[(int)SceneState.Count];
        _updateDelegates[(int)SceneState.Reset] = UpdateSceneReset;
        _updateDelegates[(int)SceneState.Preload] = UpdateScenePreload;
        _updateDelegates[(int)SceneState.Load] = UpdateSceneLoad;
        _updateDelegates[(int)SceneState.Unload] = UpdateSceneUnload;
        _updateDelegates[(int)SceneState.PostLoad] = UpdateScenePostload;
        _updateDelegates[(int)SceneState.Ready] = UpdateSceneReady;
        _updateDelegates[(int)SceneState.Run] = UpdateSceneRun;

        _currentCoreScene = CoreScene.Loader;
        _nextCoreScene = sceneToLoad;
        _sceneState = SceneState.Reset;
        _uiStack = myUIViewStack;
    }

    public void Dispose()
    {
        //Cleanup delegates
        if (_updateDelegates != null)
        {
            for (int i = 0; i < (int)SceneState.Count; i++)
            {
                _updateDelegates[i] = null;
            }
            _updateDelegates = null;
        }
    }

    public void Tick()
    {
        _updateDelegates[(int)_sceneState]?.Invoke();
    }

    public void SwitchScene(CoreScene NextSceneType)
    {
        if (_currentCoreScene != NextSceneType)
        {
            _uiStack.ClearStack();
            _nextCoreScene = NextSceneType;
        }
    }

    /// <summary>
    /// Starter of a loading cascade
    /// </summary>
    private void UpdateSceneReset()
    {
        //run a gc pass
        System.GC.Collect();
        _sceneState = SceneState.Preload;
    }

    /// <summary>
    /// Handle anything that needs to be done before loading
    /// </summary>
    private void UpdateScenePreload()
    {
        _sceneLoadTask = SceneManager.LoadSceneAsync((int)_nextCoreScene);
        _sceneState = SceneState.Load;
    }

    /// <summary>
    /// Show loading screen while loading is in process
    /// </summary>
    private void UpdateSceneLoad()
    {
        //Done loading?
        if (_sceneLoadTask.isDone == true)
        {
            _sceneState = SceneState.Unload;
        }
        else
        {
            //Update loading Progress bar
        }
    }

    /// <summary>
    /// Clean up unused resources by unloading them
    /// </summary>
    private void UpdateSceneUnload()
    {
        //cleaning up resources yet?
        if (_resourceUnloadTask == null)
        {
            _resourceUnloadTask = Resources.UnloadUnusedAssets();
        }
        else
        {
            //Done Cleaning?
            if (_resourceUnloadTask.isDone == true)
            {
                _resourceUnloadTask = null;
                _sceneState = SceneState.PostLoad;
            }
        }
    }

    /// <summary>
    /// Handle all that needs to happen immediately after loading
    /// </summary>
    private void UpdateScenePostload()
    {
        _currentCoreScene = _nextCoreScene;
        _sceneState = SceneState.Ready;
    }

    /// <summary>
    /// Handle all that needs to happen immediately before running the game
    /// </summary>
    private void UpdateSceneReady()
    {
        // run a gc pass
        //If I have loaded assets in scene that are currently unused, but may be used later
        //DON'T run this step
        System.GC.Collect();
        _sceneState = SceneState.Run;
    }

    /// <summary>
    /// Load another scene if name is different
    /// </summary>
    private void UpdateSceneRun()
    {
        if (_currentCoreScene != _nextCoreScene)
        {
            _sceneState = SceneState.Reset;
        }
    }
}