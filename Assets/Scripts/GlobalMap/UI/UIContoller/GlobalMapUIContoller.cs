using myUI;
using System.Threading.Tasks;
using Zenject;

namespace GlobalMap
{
    public class GlobalMapUIContoller : IGlobalMapUIController
    {
        readonly IMyUIViewModelsStack _UIStack;
        [Inject] GlobalMapHUDViewModel _HUD = null;
        [Inject] MapRegionViewModel _regionView = null;

        public async Task ShowGlobalMapHUDAsync()
        {
            await _HUD.Open();
        }

        public async Task ShowRegionViewAsync()
        {
            await _regionView.Open();
        }

        public void BackPressed()
        {
            throw new System.NotImplementedException();
        }

        public void ClearUIStack()
        {
            _UIStack.ClearStack();
        }
    }
}
