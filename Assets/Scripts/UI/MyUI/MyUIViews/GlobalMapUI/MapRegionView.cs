using UnityWeld.Binding;
using myUI;

[Binding]
public class MapRegionView : MyUIView<MapRegionView>
{
    public MapRegionModelView ViewModel { get { return IViewModel as MapRegionModelView; } }

    string _regionName;
    [Binding]
    public string RegionName
    {
        get { return _regionName; }
        set
        {
            if (_regionName == value) return;
            _regionName = value;
            OnPropertyChanged("RegionName");
        }
    }

    [Binding]
    public void OnClose()
    {
        ViewModel.Close();
    }

    [Binding]
    public void OnRegionEnter()
    {
        ViewModel.RegionEnter();
    }
}
