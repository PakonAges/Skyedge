using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUIViewModel
    {
        IMyUIView MyView { get; }
        Task Open();
        void CloseCommand();
        void Close();
    }
}
