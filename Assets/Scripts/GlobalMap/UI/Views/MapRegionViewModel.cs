using System;
using myUI;
using Zenject;

public class MapRegionViewModel : MyUIViewModel<MapRegionViewModel>
{
    public MapRegionView View { get { return IView as MapRegionView; } }
    public MapRegionViewModel(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    internal void RegionEnter()
    {
        throw new NotImplementedException();
    }

    public void ShowRegionInfo()
    {
        View.RegionName = "Region Name";
    }

    public void MoveHere()
    {
        //Command Hero to Move here
    }
}
