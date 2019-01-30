namespace myUI
{
    public interface IMyUIView
    {
        bool HideOnClose { get; }
        bool NeedConfirmToClose { get; }
        bool HideAllOtherViews { get; }
        void SetViewModel(IMyUIViewModel viewModel);
    }
}
