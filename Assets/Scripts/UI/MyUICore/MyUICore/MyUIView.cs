using System.ComponentModel;
using UnityEngine;

namespace myUI
{
    public abstract class MyUIView<T> : MyUIView where T : MyUIView<T>
    {
        public override void OnBackPressed()
        {
            Debug.Log("Back pressed?");
            //default implementation -> destroy?
        }
    }

    public abstract class MyUIView : MonoBehaviour, IMyUIView, INotifyPropertyChanged
    {
        public bool CacheOnClosed = false;
        public bool HideSubordinates = false;
        public bool NeedConfirmBeforeClosing = false;

        protected virtual IMyUIViewModel IViewModel { get; set; }
        public bool HideOnClose { get; private set; }
        public bool NeedConfirmToClose { get; private set; }
        public bool HideAllOtherViews { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void OnBackPressed();

        public virtual void SetViewModel(IMyUIViewModel viewModel)
        {
            IViewModel = viewModel;
            HideOnClose = CacheOnClosed;
            NeedConfirmToClose = NeedConfirmBeforeClosing;
            HideAllOtherViews = HideSubordinates;
        }
    }
}