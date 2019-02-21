using UnityEngine;
using Zenject;
using myUI;

public class HotKeyInput : MonoBehaviour, IKeyboardInput {

    public KeyCode GenerateField = KeyCode.G;
    public KeyCode FindCombos = KeyCode.F;

    public IMatchController _fieldSceneController;

    [Inject]
    public void Construct(  IMatchController fieldSceneController)
    {
        _fieldSceneController = fieldSceneController;
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
    }
}
