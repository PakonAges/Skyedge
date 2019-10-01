using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUICoreController
    {
        Task OnBackPressedAsync();
        void ClearUPOnSceneSwitching();
    }
}
