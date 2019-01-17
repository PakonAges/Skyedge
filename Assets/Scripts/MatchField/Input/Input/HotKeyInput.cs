using UnityEngine;
using Zenject;

public class HotKeyInput : MonoBehaviour, IKeyboardInput {

    public KeyCode GenerateField = KeyCode.G;
    public KeyCode FindCombos = KeyCode.F;
    public KeyCode ShowmatchHUD = KeyCode.H;

    public IFieldSceneController _fieldSceneController;
    public IUiManager _uiManager;
	
    [Inject]
    public void Construct(  IFieldSceneController fieldSceneController,
                            IUiManager uiManager)
    {
        _fieldSceneController = fieldSceneController;
        _uiManager = uiManager;
    }

	void Update () {
        if (Input.GetKeyDown(GenerateField))
        {
            _fieldSceneController.StartMatchAsync();
        }
        else if (Input.GetKeyDown(FindCombos))
        {
            //_fieldSceneController.FindCombos();
        }
        else if (Input.GetKeyDown(ShowmatchHUD))
        {
            _uiManager.OpenWindowAsync(UIViewType.MatchFieldHUD);
        }
    }
}
