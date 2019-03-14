﻿using System;
using GlobalMap;
using myUI;

public class MapRegionViewModel : MyUIViewModel<MapRegionViewModel, GlobalMapRegionData>
{
    public MapRegionView View { get { return MyView as MapRegionView; } }

    protected override GlobalMapRegionData ViewData { get; set; }

    public MapRegionViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    internal void RegionEnter()
    {
        throw new NotImplementedException();
    }

    public override void FetchData(IMyUIViewData data)
    {
        ViewData = (GlobalMapRegionData)data;
        View.RegionName = ViewData.RegionName;
    }

    public void MoveHere()
    {
        //Command Hero to Move here
    }
}
