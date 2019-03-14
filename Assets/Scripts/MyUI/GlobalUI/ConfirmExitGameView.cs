using UnityWeld.Binding;
using myUI;

[Binding]
public class ConfirmExitGameView : MyUIView<ConfirmExitGameView>
{
    public ConfirmExitGameViewModel ViewModel { get { return IViewModel as ConfirmExitGameViewModel; } }

    [Binding]
    public void OnExitGameBtn()
    {
        ViewModel.ExitGame();
    }

    [Binding]
    public void OnCancel()
    {
        ViewModel.Close();
    }
}