using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class GlobalMapView : MonoBehaviour
{
    [Inject] GlobalMapViewModel _viewModel = null;

    [Binding]
    public void OnMatchBtn()
    {
        _viewModel.LoadMatchScene();
    }

    [Binding]
    public void OnLocationBtn()
    {
        _viewModel.LoadLocationScene();
    }
}
