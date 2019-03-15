using UnityWeld.Binding;
using myUI;
using Zenject;

[Binding]
public class MatchHUDView : MyUIView<MatchHUDView, MatchHUDViewModel>
{
    [Inject] new MatchHUDViewModel MyViewModel = null;

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
        MyViewModel.ShowPauseView();
    }
}
