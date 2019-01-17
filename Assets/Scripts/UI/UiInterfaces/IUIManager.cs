using System.Threading.Tasks;

public interface IUiManager
{
    Task OpenWindowAsync(UIViewType window);
    void CloseWindow(IWindow window);
    void CloseTopWindow();
    void CloseAll();
}
