using System.Collections.Generic;
using UnityEngine;

namespace myUI
{
    public class MyUIViewModelsStack : IMyUIViewModelsStack
    {
        public Stack<IMyUIViewModel> Stack { get; set; }

        public MyUIViewModelsStack()
        {
            Stack = new Stack<IMyUIViewModel>();
        }

        public void AddViewModel(IMyUIViewModel ViewModel)
        {
            if (Stack.Count > 0)
            {
                //Hide other views on Open
                if (ViewModel.MyView.HideAllOtherViews)
                {
                    foreach (var view in Stack)
                    {
                        view.MyView.MyCanvas.enabled = false;
                    }
                }

                //Setup Canvas Sorting Order
                var TopCanvas = ViewModel.MyView.MyCanvas;
                var PreviousCanvas = Stack.Peek().MyView.MyCanvas;
                TopCanvas.sortingOrder = PreviousCanvas.sortingOrder + 1;
            }

            Stack.Push(ViewModel);
        }

        public void CloseTopView()
        {
            var TopView = Stack.Peek();
            //If all other views was closed -> show them on Close
            if (TopView.MyView.HideAllOtherViews)
            {
                foreach (var view in Stack)
                {
                    view.MyView.MyCanvas.enabled = true;
                }
            }

            TopView.Dispose();
            Stack.Pop();
        }

        //Assumes that I want to close only top view? is it correct?
        public void Close(IMyUIViewModel ViewModel)
        {
            if (Stack.Count == 0)
            {
                Debug.LogErrorFormat("Trying to close Viev: {0}, But Stack is empty", ViewModel);
                return;
            }

            if (Stack.Peek() != ViewModel)
            {
                Debug.LogErrorFormat("Trying to close View ({0}), but it isn't at the top of the Stack", ViewModel);
                return;
            }

            CloseTopView();
        }

        public void ClearStack()
        {
            if (Stack.Count > 0)
            {
                while (Stack.Count != 0)
                {
                    CloseTopView();
                }
            }
        }
    }
}
