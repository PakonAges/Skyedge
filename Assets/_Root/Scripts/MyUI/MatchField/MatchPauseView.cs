using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchPauseView : MyUIView<MatchPauseView, MatchPauseViewModel>
{
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