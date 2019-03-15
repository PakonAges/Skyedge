using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace myUI
{
    public abstract class MyUIViewModel : IMyUIViewModel, IDisposable
    {
        [Inject] readonly internal IMyUIPrefabProvider _prefabProvider = null;
        [Inject] readonly internal IMyUIViewModelsStack _stack = null;
        public IMyUIView MyView { get; set; }

        /// <summary>
        /// Open call from UI and Input. Check if there is cached View is awailable before creating new
        /// </summary>
        public abstract Task Open();
        
        /// <summary>
        /// Call from UI and Input
        /// </summary>
        public abstract void Close();

        public abstract void Dispose();
    }

    public abstract class MyUIViewModel<TViewModel> : MyUIViewModel where TViewModel : class, IMyUIViewModel
    {
        public async override Task Open()
        {
            await ShowViewAsync();
            _stack.AddViewModel(this);
        }

        protected async Task ShowViewAsync()
        {
            if (MyView != null && MyView.HideOnClose)
            {
                if (!MyView.MyCanvas)
                {
                    Debug.LogErrorFormat("Trying to enable Canvas on Cached View ({0}), but there is no canvas", this);
                    return;
                }

                MyView.MyCanvas.enabled = true;
            }
            else
            {
                try
                {
                    var Prefab = await _prefabProvider.GetWindowPrefab<TViewModel>();
                    var ViewGo = GameObject.Instantiate(Prefab);
                    MyView = ViewGo.GetComponent<IMyUIView>();
                    MyView.SetViewModel(this);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
        }

        public override void Dispose()
        {
            if (MyView == null || MyView.MyCanvas == null)
            {
                return;
            }
            else
            {
                GameObject.Destroy(MyView.MyCanvas.gameObject);
            }
        }

        public override void Close()
        {
            _stack.Close(this);
        }
    }

    public abstract class MyUIViewModel<TViewModel, TData> : MyUIViewModel<TViewModel> where TViewModel : class, IMyUIViewModel where TData : class, IMyUIViewData
    {
        protected abstract TData ViewData { get; set; }

        public async Task Open(IMyUIViewData data)
        {
            await ShowViewAsync();
            FetchData(data);
            _stack.AddViewModel(this);
        }

        public abstract void FetchData(IMyUIViewData data);
    }
}