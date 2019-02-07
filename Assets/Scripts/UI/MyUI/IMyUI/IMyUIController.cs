using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUIController
    {
        Task ShowHUD();
        void BackPressed();
    }
}