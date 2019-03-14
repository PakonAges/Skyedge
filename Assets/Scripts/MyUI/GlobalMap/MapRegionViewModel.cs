using System;
using myUI;
using Zenject;

public class MapRegionViewModel : MyUIViewModel<MapRegionViewModel>
{
    public MapRegionView View { get { return MyView as MapRegionView; } }

    //protected override GlobalMapRegionData DefaultOptions { get; }

    public MapRegionViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    internal void RegionEnter()
    {
        throw new NotImplementedException();
    }

    //protected override void FetchData(IMyUIViewData data)
    //{
    //    View.RegionName = (GlobalMapRegionData)data;
    //}

    public void MoveHere()
    {
        //Command Hero to Move here
    }
}
