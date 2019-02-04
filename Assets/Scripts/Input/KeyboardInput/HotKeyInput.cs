using UnityEngine;
using Zenject;
using myUI;

public class HotKeyInput : MonoBehaviour, IKeyboardInput {

    public KeyCode GenerateField = KeyCode.G;
    public KeyCode FindCombos = KeyCode.F;

    public IFieldSceneController _fieldSceneController;
    public IMyUIController _UIController;

    [Inject]
    public void Construct(  IFieldSceneController fieldSceneController,
                            IMyUIController myUIController)
    {
        _fieldSceneController = fieldSceneController;
        _UIController = myUIController;
    }

	void Update () {
        if (Input.GetKeyDown(GenerateField))
        {
            _fieldSceneController.StartMatchAsync();
            _UIController.ShowHUD();
        }
        else if (Input.GetKeyDown(FindCombos))
        {
            //_fieldSceneController.FindCombos();
        }
    }
}
