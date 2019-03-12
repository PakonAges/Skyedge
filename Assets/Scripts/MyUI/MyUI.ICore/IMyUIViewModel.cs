using System.Threading.Tasks;

namespace myUI
{
    public interface IMyUIViewModel
    {
        IMyUIView MyView { get; set; }
        Task Open();
        void CloseCommand();
        void Close();
    }
}
