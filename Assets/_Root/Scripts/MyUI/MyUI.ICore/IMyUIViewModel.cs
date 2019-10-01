using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUIViewModel
    {
        IMyUIView MyView { get; }
        Task Open();
        void Close();
        void Dispose();
        void SetView(IMyUIView view);
    }
}
