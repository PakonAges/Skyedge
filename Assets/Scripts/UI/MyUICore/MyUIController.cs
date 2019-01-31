using Zenject;

namespace myUI
{
    public class MyUIController : IMyUIController
    {
        [Inject] MatchHUDViewModel _HUD;

        public async void ShowHUD()
        {
            await _HUD.Open();
        }
    }
}