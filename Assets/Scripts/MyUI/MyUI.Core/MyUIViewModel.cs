using System;
using System.Threading.Tasks;
using UnityEngine;

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
            if (MyView != null && MyView.HideOnClose)
            {
                if (!MyView.MyCanvas)
                {
                    Debug.LogErrorFormat("Trying to enable Canvas on Cached View ({0}), but there is no canvas", this);
                    return;
                }

                MyView.MyCanvas.enabled = true;
                _stack.AddViewModel(this);
            }
            else
            {
                await ShowViewAsync();
            }
        }

        // TODO : how to fetch Data, like Region Data?
        public async override Task Open(IMyUIViewData data)
        {
            //Already been created
            if (MyView != null && MyView.HideOnClose)
            {
                if (!MyView.MyCanvas)
                {
                    Debug.LogErrorFormat("Trying to enable Canvas on Cached View ({0}), but there is no canvas", this);
                    return;
                }

                MyView.MyCanvas.enabled = true;
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
                MyView = ViewGo.GetComponent<IMyUIView>();
                MyView.SetViewModel(this);
                _stack.AddViewModel(this);
            }
            catch (Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public override void Dispose()
        {
            if (MyView == null || MyView.MyCanvas == null)
            {
                return;
            }

            //if (MyView.HideOnClose)
            //{
            //    MyView.MyCanvas.enabled = false;
            //}
            //else
            //{
                if (MyView.MyCanvas)
                {
                    GameObject.Destroy(MyView.MyCanvas.gameObject);
                }
            //}
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

    public abstract class MyUIViewModel : IMyUIViewModel, IDisposable
    {
        public IMyUIPrefabProvider _prefabProvider;
        public IMyUIViewModelsStack _stack;
        public IMyUIView MyView { get; set; }

        public abstract void Dispose();

        /// <summary>
        /// Open call from UI and Input. Check if there is cached View is awailable before creating new
        /// </summary>
        public abstract Task Open();

        /// <summary>
        /// Open Window With some Parameters/Data
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public abstract Task Open(IMyUIViewData data);
        
        /// <summary>
        /// Call from UI and Input
        /// </summary>
        public abstract void Close();

        /// <summary>
        /// Call from Stack
        /// </summary>
        public abstract void CloseCommand();

    }
}