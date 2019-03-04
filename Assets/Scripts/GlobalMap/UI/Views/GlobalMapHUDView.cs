using myUI;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class GlobalMapHUDView : MyUIView<GlobalMapHUDView>
{
    public GlobalMapHUDViewModel ViewModel { get { return IViewModel as GlobalMapHUDViewModel; } }
   
    [Binding]
    public void OnMatchBtn()
    {
        ViewModel.LoadMatchScene();
    }

    [Binding]
    public void OnLocationBtn()
    {
        ViewModel.LoadLocationScene();
    }
}
