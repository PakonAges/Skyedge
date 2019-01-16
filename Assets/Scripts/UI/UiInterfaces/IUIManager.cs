public interface IUIManager
{
    void OpenWindow(IView window);
    void CloseWindow(IView window);
    void CloseTopWindow();
    void CloseAll();
}
