using UnityEngine;
using Zenject;

public class UiController : MonoBehaviour
{
    IUiManager _uiManager;

    [Inject]
    public void Construct(IUiManager uiManager)
    {
        _uiManager = uiManager;
    }

    void Start()
    {
        _uiManager.OpenWindowAsync(UIViewType.MatchFieldHUD);
    }
}
