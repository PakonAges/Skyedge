using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchHUDView : MyUIView<MatchHUDView>
{
    public MatchHUDViewModel ViewModel { get { return IViewModel as MatchHUDViewModel; } }
}
