using System;
using GlobalMap;
using myUI;

public class MapRegionViewModel : MyUIViewModel<MapRegionViewModel, MapRegionView, GlobalMapRegionData>
{
    protected override void ApplyData()
    {
        MyView.RegionName = MyViewData.RegionName;
    }

    internal void RegionEnter()
    {
        throw new NotImplementedException();
    }

    public void MoveHere()
    {
        //Command Hero to Move here
    }

}
