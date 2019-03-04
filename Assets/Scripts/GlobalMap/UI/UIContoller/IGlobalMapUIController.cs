using System.Threading.Tasks;

namespace GlobalMap
{
    public interface IGlobalMapUIController
    {
        Task ShowGlobalMapHUDAsync();
        Task ShowRegionViewAsync(/*Reion Data*/);
        void BackPressed();
        void ClearUIStack();
    }
}