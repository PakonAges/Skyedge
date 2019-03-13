using System;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace myUI
{
    public class MyUICoreController : IMyUICoreController
    {
        readonly IMyUIViewModelsStack _uiStack;
        [Inject] readonly ConfirmExitGameViewModel _confirmCloseGame = null;

        public MyUICoreController(  IMyUIViewModelsStack uIViewModelsStack)
        {
            _uiStack = uIViewModelsStack;
        }

        public async Task OnBackPressedAsync()
        {
            if (_uiStack.Stack.Count > 0)
            {
                _uiStack.CloseTopView();
            }
            else
            {
                try
                {
                    await _confirmCloseGame.Open();
                }
                catch (Exception e)
                {
                    Debug.LogError(e.Message);
                }
            }
        }

        public void ClearUPOnSceneSwitching()
        {
            _uiStack.ClearStack();
        }
    }
}