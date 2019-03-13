using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUIViewModel
    {
        IMyUIView MyView { get; }
        Task Open();
        Task Open(IMyUIViewData data);
        void CloseCommand();
        void Close();
    }
}
