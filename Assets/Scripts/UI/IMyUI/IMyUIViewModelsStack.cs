using System.Collections.Generic;

namespace myUI
{
    public interface IMyUIViewModelsStack
    {
        Stack<MyUIViewModel> Stack { get; set; }
        void AddViewModel(MyUIViewModel ViewModel);
        void CloseTopView();
        void Close(MyUIViewModel ViewModel);
    }
}
