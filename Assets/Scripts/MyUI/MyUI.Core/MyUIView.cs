using System.ComponentModel;
using UnityEngine;

namespace myUI
{
    public abstract class MyUIView<T> : MyUIView where T : MyUIView<T>
    {
    }

    public abstract class MyUIView : MonoBehaviour, IMyUIView, INotifyPropertyChanged
    {
        public bool CacheOnClosed = false;
        public bool HideSubordinates = false;

        protected virtual IMyUIViewModel IViewModel { get; set; }
        public bool HideOnClose { get; private set; }
        public bool HideAllOtherViews { get; private set; }
        public Canvas MyCanvas { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void SetViewModel(IMyUIViewModel viewModel)
        {
            IViewModel = viewModel;
            HideOnClose = CacheOnClosed;
            HideAllOtherViews = HideSubordinates;
            MyCanvas = gameObject.GetComponent<Canvas>();
        }
    }
}