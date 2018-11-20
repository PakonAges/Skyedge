using UnityEngine;
using Zenject;

public class HotKeyInput : MonoBehaviour {

    public KeyCode GenerateField = KeyCode.G;
    public KeyCode ResetField = KeyCode.R;

    private IFieldSceneController _fieldSceneController;
	
    [Inject]
    public void Construct(IFieldSceneController fieldSceneController)
    {
        _fieldSceneController = fieldSceneController;
    }

	void Update () {
        if (Input.GetKeyDown(GenerateField))
        {
            _fieldSceneController.GenerateField();
        }
        else if(Input.GetKeyDown(ResetField))
        {
            _fieldSceneController.ResetField();
        }
    }
}
