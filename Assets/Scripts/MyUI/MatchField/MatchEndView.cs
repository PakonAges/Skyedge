using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchEndView : MyUIView<MatchEndView, MatchEndViewModel>
{
    //public MatchEndViewModel ViewModel { get { return IViewModel as MatchEndViewModel; } }

    [Binding]
    public void OnClose()
    {
        MyViewModel.ExitToTheMap();
    }

    [Binding]
    public void OnRestart()
    {
        MyViewModel.RestartLevel();
    }
}
