using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchHUDView : MyUIView<MatchHUDView>
{
    public MatchHUDViewModel ViewModel { get { return IViewModel as MatchHUDViewModel; } }

    string _turnsCounter;
    [Binding]  public string TurnsCounter
    {
        get { return _turnsCounter; }
        set
        {
            if (_turnsCounter == value) return;
            _turnsCounter = value;
            OnPropertyChanged("TurnsCounter");
        }
    }

    [Binding]
    public void OnPauseBtnClick()
    {
        ViewModel.ShowPauseView();
    }
}
