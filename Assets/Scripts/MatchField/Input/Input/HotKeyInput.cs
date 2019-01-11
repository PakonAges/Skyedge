using UnityEngine;
using Zenject;

public class HotKeyInput : MonoBehaviour {

    public KeyCode GenerateField = KeyCode.G;
    public KeyCode FindCombos = KeyCode.F;

    public IFieldSceneController _fieldSceneController;
	
    [Inject]
    public void Construct(IFieldSceneController fieldSceneController)
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
