using UnityWeld.Binding;
using myUI;

[Binding]
public class MapRegionView : MyUIView<MapRegionView, MapRegionViewModel>
{
    //protected override MapRegionViewModel MyViewModel { get { return IViewModel as MapRegionViewModel; } }

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
        MyViewModel.Close();
    }

    [Binding]
    public void OnRegionEnter()
    {
        MyViewModel.RegionEnter();
    }

    [Binding]
    public void OnMoveHere()
    {
        MyViewModel.MoveHere();
    }

}
