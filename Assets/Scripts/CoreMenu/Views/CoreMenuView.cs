using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class CoreMenuView : MonoBehaviour
{
    [Inject] CoreMenuViewModel _viewModel = null;

    [Binding]
    public void OnMatchBtn()
    {
        _viewModel.LoadMatchScene();
    }

    [Binding]
    public void OnMapBtn()
    {
        _viewModel.LoadMapScene();
    }

    [Binding]
    public void OnLocationBtn()
    {
        _viewModel.LoadLocationScene();
    }
}
