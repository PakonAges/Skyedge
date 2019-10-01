using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class LobbyView : MonoBehaviour
{
    [Inject] LobbyViewModel _viewModel = null;

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

    [Binding]
    public void OnRegionBtn()
    {
        _viewModel.LoadRegionScene();
    }
}
