using System.Collections.Generic;
using UnityEngine;

namespace myUI
{
    public class MyUIViewModelsStack : IMyUIViewModelsStack
    {
        public Stack<MyUIViewModel> Stack { get; set; }

        public MyUIViewModelsStack()
        {
            Stack = new Stack<MyUIViewModel>();
        }

        public void AddViewModel(MyUIViewModel ViewModel)
        {
            if (Stack.Count > 0)
            {
                //Hide other views on Open
                if (ViewModel.IView.HideAllOtherViews)
                {
                    foreach (var view in Stack)
                    {
                        view.Canvas.enabled = false;
                    }
                }

                //Setup Canvas Sorting Order
                var TopCanvas = ViewModel.Canvas;
                var PreviousCanvas = Stack.Peek().Canvas;
                TopCanvas.sortingOrder = PreviousCanvas.sortingOrder + 1;
            }

            Stack.Push(ViewModel);
        }

        public void CloseTopView()
        {
            var TopView = Stack.Peek();
            //If all other views was closed -> show them on Close
            if (TopView.IView.HideAllOtherViews)
            {
                foreach (var view in Stack)
                {
                    view.Canvas.enabled = true;
                }
            }

            TopView.CloseCommand();
            Stack.Pop();
        }

        //Assumes that I want to close only top view? is it correct?
        public void Close(MyUIViewModel ViewModel)
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
