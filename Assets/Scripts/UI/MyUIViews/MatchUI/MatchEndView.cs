using UnityWeld.Binding;
using myUI;

[Binding]
public class MatchEndView : MyUIView<MatchEndView>
{
    public MatchEndViewModel ViewModel { get { return IViewModel as MatchEndViewModel; } }
}
