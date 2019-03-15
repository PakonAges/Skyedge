namespace GlobalMap
{
    using System.Threading.Tasks;
    using UnityEngine;
    using Zenject;

    public class GlobalMapRegion : MonoBehaviour, IGlobalMapRegion, IClickable
    {
        public GlobalMapRegionData Data;
        //Roads?

        [Inject] readonly MapRegionViewModel _regionView = null;

        public async Task OnClickedAsync()
        {
            try
            {
                await _regionView.Open(Data);
            }
            catch (System.Exception e)
            {
                Debug.LogError(e.Message);
            }
        }
    }
}