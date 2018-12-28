using DigitalRubyShared;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    GameObject _selectedObject = null;
    bool _alreadyHasSelection = false;
    GameObject _selectionVisual;

    GameObject _selectedChipVisualizationPrefab;
    TapGestureRecognizer _tapGesture;
    Camera _camera;

    [Inject]
    public void Construct(  Camera cam,
                            FieldVisualizationParameters fieldVisualizationParameters)
    {
        _camera = cam;
        _selectedChipVisualizationPrefab = fieldVisualizationParameters.SelectedChip;
        CreateTapGesture();
    }

    void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            Vector3 pos = new Vector3(gesture.FocusX, gesture.FocusY, 0.0f);
            pos = _camera.ScreenToWorldPoint(pos);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);
            if (hit.transform != null)
            {
                SelectObject(hit.transform.gameObject);
                //Debug.LogFormat("Clicked on: {0}", hit.transform);
            }
            else
            {
                _tapGesture.Reset();
            }
        }
    }

    void CreateTapGesture()
    {
        _tapGesture = new TapGestureRecognizer();
        _tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(_tapGesture);
    }

    void SelectObject(GameObject selectedGo)
    {
        _selectedObject = selectedGo;

        if (!_alreadyHasSelection)
        {
            _selectionVisual = CreateSelectionView(selectedGo.transform.position);
            _alreadyHasSelection = true;
        }
        else
        {
            MoveSelection(selectedGo.transform.position);
        }
    }


    GameObject CreateSelectionView(Vector3 position)
    {
        GameObject o = Instantiate(_selectedChipVisualizationPrefab) as GameObject;
        o.name = "Selection";
        o.transform.position = position;
        return o;
    }

    void MoveSelection(Vector3 newPosition)
    {
        if (_selectionVisual)
        {
            _selectionVisual.transform.position = newPosition;
        }
        else
        {
            Debug.LogError("Trying to move Selection View, but there is no one");
        }
    }
}
