using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace myUI
{
    public abstract class MyUIViewModel<T> : MyUIViewModel where T : MyUIViewModel<T>
    {
        public MyUIViewModel(   IMyUIPrefabProvider prefabProvider,
                                IMyUIViewModelsStack uIViewModelsStack)
        {
            _stack = uIViewModelsStack;
            _prefabProvider = prefabProvider;
        }

        public async override Task Open()
        {
            //Already been created
            if (IView != null && IView.HideOnClose)
            {
                if (!Canvas)
                {
                    Debug.LogErrorFormat("Trying to enable Canvas on Cached View ({0}), but there is no canvas", this);
                    return;
                }

                Canvas.enabled = true;
                _stack.AddViewModel(this);
            }
            else
            {
                await ShowViewAsync();
            }
        }

        public virtual async Task ShowViewAsync()
        {
            try
            {
                var Prefab = await _prefabProvider.GetWindowPrefab<T>();
                var ViewGo = GameObject.Instantiate(Prefab);
                IView = ViewGo.GetComponent<IMyUIView>();
                IView.SetViewModel(this);
                //SceneManager.MoveGameObjectToScene(ViewGo, _prefabProvider.UIScene);
                Canvas = ViewGo.GetComponent<Canvas>();
                _stack.AddViewModel(this);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public override void Dispose()
        {
            if (IView == null || Canvas == null)
            {
                return;
            }

            if (IView.HideOnClose)
            {
                Canvas.enabled = false;
            }
            else
            {
                if (Canvas)
                {
                    GameObject.Destroy(Canvas.gameObject);
                }
            }
        }

        public override void CloseCommand()
        {
            Dispose();
        }

        public override void Close()
        {
            _stack.Close(this);
        }
    }

    public abstract class MyUIViewModel : IMyUIViewModel, IInitializable, IDisposable
    {
        internal IMyUIPrefabProvider _prefabProvider;
        internal IMyUIViewModelsStack _stack;
        internal virtual IMyUIView IView { get; set; }
        internal Canvas Canvas;

        public virtual void Initialize() { }
        public virtual void Dispose() { }

        /// <summary>
        /// Open call from UI and Input. Check if there is cached View is awailable before creating new
        /// </summary>
        public virtual Task Open() { return null; }

        /// <summary>
        /// Call from UI and Input
        /// </summary>
        public virtual void Close() { }

        /// <summary>
        /// Call from UI Stack
        /// </summary>
        public virtual void CloseCommand() { }

        /// <summary>
        /// ON close -> Show confirm Pop Up without closing View
        /// </summary>
        public virtual void ShowConfirmToClose() { }
    }
}