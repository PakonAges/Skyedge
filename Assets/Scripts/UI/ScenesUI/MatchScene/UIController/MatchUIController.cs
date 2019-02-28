using System.Threading.Tasks;
using Zenject;

namespace myUI
{
    public class MatchUIController : IMatchUIController
    {
        readonly IMyUIViewModelsStack _UIStack;
        [Inject] MatchHUDViewModel _HUD = null;

        public MatchUIController(IMyUIViewModelsStack stack)
        {
            _UIStack = stack;
        }

        public void BackPressed()
        {
            _UIStack.Stack.Peek().Close();
        }

        public void ClearUIStack()
        {
            _UIStack.ClearStack();
        }

        public async Task ShowHUD()
        {
            await _HUD.Open();
        }
    }
}