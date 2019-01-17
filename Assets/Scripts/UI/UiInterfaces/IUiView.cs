public interface IUiView
{
    bool DestroyWhenClosed { get; }
    UIViewType ViewType { get; }

    void Close();
    void Show();
    void OnBackPressed();
}
