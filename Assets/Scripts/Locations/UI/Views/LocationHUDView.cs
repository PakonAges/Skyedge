using UnityEngine;
using UnityWeld.Binding;
using Zenject;

[Binding]
public class LocationHUDView : MonoBehaviour
{
    [Inject] LocationHUDViewModel _viewModel = null;

    [Binding]
    public void OnLocationBtn()
    {
        _viewModel.LoadLocationScene();
    }
}
