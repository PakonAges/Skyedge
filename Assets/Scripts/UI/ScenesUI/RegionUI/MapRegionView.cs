using UnityWeld.Binding;
using myUI;

[Binding]
public class MapRegionView : MyUIView<MapRegionView>
{
    public MapRegionViewModel ViewModel { get { return IViewModel as MapRegionViewModel; } }

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
