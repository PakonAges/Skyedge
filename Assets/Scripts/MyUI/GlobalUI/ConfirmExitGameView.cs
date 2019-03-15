using UnityWeld.Binding;
using myUI;

[Binding]
public class ConfirmExitGameView : MyUIView<ConfirmExitGameView, ConfirmExitGameViewModel>
{
    //public ConfirmExitGameViewModel MyViewModel { get { return IViewModel as ConfirmExitGameViewModel; } }
    [Binding]
    public void OnExitGameBtn()
    {
        MyViewModel.ExitGame();
    }

    [Binding]
    public void OnCancel()
    {
        MyViewModel.Close();
    }
}