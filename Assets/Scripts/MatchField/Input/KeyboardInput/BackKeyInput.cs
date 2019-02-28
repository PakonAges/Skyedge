using UnityEngine;
using Zenject;
using myUI;

public class BackKeyInput : MonoBehaviour
{
    public KeyCode BackKey = KeyCode.Escape;
    public IMyUIViewModelsStack _UIStack;

    [Inject]
    public void Construct(IMyUIViewModelsStack viewModelsStack)
    {
        _UIStack = viewModelsStack;
    }

    void Update()
    {
        if (Input.GetKeyDown(BackKey) && _UIStack.Stack.Count > 0)
        {
            _UIStack.Stack.Peek().Close();
        }
    }
}
