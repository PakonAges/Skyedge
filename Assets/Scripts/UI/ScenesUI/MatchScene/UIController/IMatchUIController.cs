using System.Threading.Tasks;

namespace myUI
{
    public interface IMatchUIController
    {
        Task ShowHUD();
        void BackPressed();
        void ClearUIStack();
    }
}