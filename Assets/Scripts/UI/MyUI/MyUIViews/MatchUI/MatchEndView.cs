using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchEndView : MyUIView<MatchEndView>
{
    public MatchEndViewModel ViewModel { get { return IViewModel as MatchEndViewModel; } }

    [Binding]
    public void OnClose()
    {
        ViewModel.ExitToTheMap();
    }

    [Binding]
    public void OnRestart()
    {
        ViewModel.RestartLevel();
    }
}
