using System.Threading.Tasks;

namespace myUI
{
    public interface IMapUIController
    {
        Task ShowHUD();
        void BackPressed();
        void ClearUIStack();
    }
}
