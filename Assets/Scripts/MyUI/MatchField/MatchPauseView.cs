using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchPauseView : MyUIView<MatchPauseView, MatchPauseViewModel>
{
    //public MatchPauseViewModel MyViewModel { get { return IViewModel as MatchPauseViewModel; } }
    [Binding]
    public void OnClose()
    {
        MyViewModel.Close();
    }

    [Binding]
    public void OnMatchRestart()
    {
        MyViewModel.RestartMatch();
    }

    [Binding]
    public void OnExitToMap()
    {
        MyViewModel.ExitToTheMap();
    }
}