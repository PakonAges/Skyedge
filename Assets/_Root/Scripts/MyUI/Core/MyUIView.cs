using System.ComponentModel;
using UnityEngine;

namespace myUI
{
    public abstract class MyUIView<TView, TViewModel> : MonoBehaviour, IMyUIView, INotifyPropertyChanged where TView : class, IMyUIView where TViewModel : class, IMyUIViewModel
    {
        public bool CacheOnClosed = false;
        public bool HideSubordinates = false;

        protected virtual TViewModel MyViewModel { get; private set; }
        public bool HideOnClose { get; private set; }
        public bool HideAllOtherViews { get; private set; }
        public Canvas MyCanvas { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void SetViewModel(IMyUIViewModel vm)
        {
            MyViewModel = (TViewModel)vm;
        }



        void Start()
        {
            HideOnClose = CacheOnClosed;
            HideAllOtherViews = HideSubordinates;
            MyCanvas = gameObject.GetComponent<Canvas>();
        }
    }
}