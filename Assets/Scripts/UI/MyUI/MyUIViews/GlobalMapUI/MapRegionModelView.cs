using System;
using myUI;
using Zenject;

public class MapRegionModelView : MyUIViewModel<MapRegionModelView>
{
    public MapRegionView View { get { return IView as MapRegionView; } }
    public MapRegionModelView(IMyUIPrefabProvider prefabProvider, IMyUIViewModelsStack uIViewModelsStack) : base(prefabProvider, uIViewModelsStack) { }

    internal void RegionEnter()
    {
        throw new NotImplementedException();
    }

    public void ShowRegionInfo()
    {
        View.RegionName = "Region Name";
    }
}
