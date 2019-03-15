using myUI;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class GlobalMapHUDView : MyUIView<GlobalMapHUDView, GlobalMapHUDViewModel>
{
    [Inject] new GlobalMapHUDViewModel MyViewModel = null;
    //protected override GlobalMapHUDViewModel MyViewModel { get; set; }

    [Binding]
    public void OnMatchBtn()
    {
        MyViewModel.LoadMatchScene();
    }

    [Binding]
    public void OnLocationBtn()
    {
        MyViewModel.LoadLocationScene();
    }
}
