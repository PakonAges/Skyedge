using UnityEngine;
using Zenject;
using myUI;

public class BackKeyInput : MonoBehaviour
{
    public KeyCode BackKey = KeyCode.Escape;
    IMyUICoreController _uiController;

    [Inject]
    public void Construct(IMyUICoreController myUICoreController)
    {
        _uiController = myUICoreController;
    }

    void Update()
    {
        if (Input.GetKeyDown(BackKey))
        {
            _uiController.OnBackPressedAsync();
        }
    }
}
