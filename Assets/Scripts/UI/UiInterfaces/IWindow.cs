public interface IWindow
{
    //When Open another View -> don't kill this,  just hide it
    void Hide();
    void Show();
    void OnBackPressed();
}
