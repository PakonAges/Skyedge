using System.Collections.Generic;

namespace myUI
{
    public interface IMyUIViewModelsStack
    {
        Stack<IMyUIViewModel> Stack { get; set; }
        void AddViewModel(IMyUIViewModel ViewModel);
        void CloseTopView();
        void Close(IMyUIViewModel ViewModel);
        void ClearStack();
    }
}
