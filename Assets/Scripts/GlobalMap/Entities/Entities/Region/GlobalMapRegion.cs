namespace GlobalMap
{
    using System.Threading.Tasks;
    using UnityEngine;
    using Zenject;

    public class GlobalMapRegion : MonoBehaviour, IGlobalMapRegion, IClickable
    {
        public GlobalMapRegionData Data;
        //Info
        //Roads?

        //[Inject] readonly MapRegionViewModel _regionView = null;

        public async Task OnClickedAsync()
        {
            //await _regionView.Open(Data);
        }
    }
}