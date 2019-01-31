using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchPauseView : MyUIView<MatchPauseView>
{
    public MatchPauseViewModel ViewModel { get { return IViewModel as MatchPauseViewModel; } }

    [Binding]
    public void OnClose()
    {
        ViewModel.Close();
    }
}