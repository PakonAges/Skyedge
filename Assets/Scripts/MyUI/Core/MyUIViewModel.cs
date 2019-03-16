using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace myUI
{
    public abstract class MyUIViewModel<TViewModel, TView> : IMyUIViewModel, IDisposable where TViewModel : class, IMyUIViewModel where TView : class, IMyUIView
    {
        [Inject] readonly internal IMyUIPrefabProvider _prefabProvider = null;
        [Inject] readonly internal IMyUIViewModelsStack _stack = null;
        public virtual TView MyView { get; private set; }
        IMyUIView IMyUIViewModel.MyView { get { return MyView; } }

        public void SetView(IMyUIView view)
        {
            MyView = (TView)view;
        }

        public virtual async Task Open()
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
                    MyView = ViewGo.GetComponent<TView>();
                    MyView.SetViewModel(this);
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
        }

        public virtual void Dispose()
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

        public virtual void Close()
        {
            _stack.Close(this);
        }
    }

    public abstract class MyUIViewModel<TViewModel, TView, TData> : MyUIViewModel<TViewModel, TView> where TViewModel : class, IMyUIViewModel where TView : class, IMyUIView where TData : class, IMyUIViewData
    {
        protected virtual TData MyViewData { get; private set; }

        public async Task Open(IMyUIViewData data)
        {
            await ShowViewAsync();
            FetchData(data);
            _stack.AddViewModel(this);
        }

        protected virtual void FetchData(IMyUIViewData data)
        {
            MyViewData = (TData)data;
            ApplyData();
        }

        protected abstract void ApplyData();
    }
}