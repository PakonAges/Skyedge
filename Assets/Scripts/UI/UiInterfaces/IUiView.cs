public interface IUiView
{
    IUiManager UiManager { get; }
    bool DestroyWhenClosed { get; }
    UIViewType ViewType { get; }

    void Init(IUiManager uiManager, UIViewType type, bool DestroyOnClosed);
    void Close();
    void Show();
    void OnBackPressed();
}
