using myUI;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class GlobalMapHUDView : MyUIView<GlobalMapHUDView, GlobalMapHUDViewModel>
{
    [Inject] new GlobalMapHUDViewModel MyViewModel = null;

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
