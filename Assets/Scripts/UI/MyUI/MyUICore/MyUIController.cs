using System.Threading.Tasks;
using Zenject;

namespace myUI
{
    public class MyUIController : IMyUIController
    {
        readonly IMyUIViewModelsStack _UIStack;
        [Inject] MatchHUDViewModel _HUD = null;

        public MyUIController(IMyUIViewModelsStack stack)
        {
            _UIStack = stack;
        }

        public void BackPressed()
        {
            _UIStack.CloseTopView();
        }

        public async Task ShowHUD()
        {
            await _HUD.Open();
        }
    }
}