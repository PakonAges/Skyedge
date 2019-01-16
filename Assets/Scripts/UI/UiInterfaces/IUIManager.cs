public interface IUiManager
{
    void OpenWindow(IWindow window);
    void CloseWindow(IWindow window);
    void CloseTopWindow();
    void CloseAll();
}
