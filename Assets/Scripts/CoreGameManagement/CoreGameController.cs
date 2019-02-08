using UnityEngine;
using UnityEngine.SceneManagement;

//Manages High Level application
//Scene Loading State Machine

public class CoreGameController : MonoBehaviour
{
    private static CoreGameController _coreGameController;

    private CoreScene _currentSceneType;
    private CoreScene _nextSceneType;
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

    public static void SwitchScene(CoreScene NextSceneType)
    {
        if (_coreGameController != null)
        {
            if (_coreGameController._currentSceneType != NextSceneType)
            {
                _coreGameController._nextSceneType = NextSceneType;
            }
        }
    }

    protected void Awake()
    {
        //Let's keep this alive between scene changes
        DontDestroyOnLoad(gameObject);

        //Setup Singleton instance
        _coreGameController = this;

        //Setup array of delegates
        _updateDelegates = new UpdateDelegate[(int)SceneState.Count];
        _updateDelegates[(int)SceneState.Reset] = UpdateSceneReset;
        _updateDelegates[(int)SceneState.Preload] = UpdateScenePreload;
        _updateDelegates[(int)SceneState.Load] = UpdateSceneLoad;
        _updateDelegates[(int)SceneState.Unload] = UpdateSceneUnload;
        _updateDelegates[(int)SceneState.PostLoad] = UpdateScenePostload;
        _updateDelegates[(int)SceneState.Ready] = UpdateSceneReady;
        _updateDelegates[(int)SceneState.Run] = UpdateSceneRun;

        _nextSceneType = CoreScene.MainMenu;

        _sceneState = SceneState.Reset;
    }

    protected void OnDestroy()
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

        //Clean Singleton instance
        if (_coreGameController != null)
        {
            _coreGameController = null;
        }
    }

    protected void Update()
    {
        _updateDelegates[(int)_sceneState]?.Invoke();
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
        _sceneLoadTask = SceneManager.LoadSceneAsync((int)_nextSceneType);
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
        _currentSceneType = _nextSceneType;
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
        if (_currentSceneType != _nextSceneType)
        {
            _sceneState = SceneState.Reset;
        }
    }
}

public enum CoreScene
{
    Loader = 0,
    MainMenu = 1,
    Map = 2,
    Location = 3,
    Match = 4
}