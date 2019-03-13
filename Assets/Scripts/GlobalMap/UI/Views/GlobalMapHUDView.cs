using myUI;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class GlobalMapHUDView : MyUIView<GlobalMapHUDView>
{
    [Inject] GlobalMapHUDViewModel ViewModel = null;
   
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
