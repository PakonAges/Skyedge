using DigitalRubyShared;
using System;
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
    IChipMovement _chipMovement;
    IFieldCleaner _fieldCleaner;
    IMatchChecker _matchChecker;
    IPlayerController _playerController;

    [Inject]
    public void Construct(  Camera cam,
                            FieldVisualizationParameters fieldVisualizationParameters,
                            IChipMovement chipMovement,
                            IFieldCleaner fieldCleaner,
                            IMatchChecker matchChecker,
                            IPlayerController playerController)
    {
        _camera = cam;
        _selectedChipVisualizationPrefab = fieldVisualizationParameters.SelectedChip;
        _chipMovement = chipMovement;
        _fieldCleaner = fieldCleaner;
        _matchChecker = matchChecker;
        _playerController = playerController;
        InitTapGesture();
        InitSelectionView();
    }

    void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            Vector3 pos = new Vector3(gesture.FocusX, gesture.FocusY, 0.0f);
            pos = _camera.ScreenToWorldPoint(pos);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

            if (hit.transform != null) // no hit
            {
                if (_selectedObject == null) //no selection
                {
                    SelectObject(hit.transform.gameObject);
                }
                else if (_selectedObject == hit.transform.gameObject) //clicked the same item
                {
                    Deselect();
                }
                else if (_chipMovement.GameField.IsAdjacement(_selectedObject.GetComponent<IChip>(),hit.transform.gameObject.GetComponent<IChip>())) //Second Chip is Adjacement
                {
                    SwapChips(_selectedObject, hit.transform.gameObject);
                }
                else //Second chip is not Adjacement
                {
                    ChangeSelection(hit.transform.gameObject);
                }
                //Debug.LogFormat("Clicked on: {0}", hit.transform);
            }
        }
    }

    void InitTapGesture()
    {
        _tapGesture = new TapGestureRecognizer();
        _tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(_tapGesture);
    }

    void InitSelectionView()
    {
        _selectionVisual = Instantiate(_selectedChipVisualizationPrefab) as GameObject;
        _selectionVisual.name = "Selection";
        _selectionVisual.SetActive(false);
        _alreadyHasSelection = false;
    }

    void SelectObject(GameObject selectedGo)
    {
        if (_selectedObject == selectedGo)
        {
            Deselect();
        }
        else
        {
            _selectedObject = selectedGo;

            if (!_alreadyHasSelection)
            {
                ShowSelectionAt(selectedGo.transform.position);
                _alreadyHasSelection = true;
            }
            else
            {
                MoveSelection(selectedGo.transform.position);
            }
        }
    }

    void ChangeSelection(GameObject obj)
    {
        _selectedObject = obj;
        _selectionVisual.transform.position = obj.transform.position;
    }

    void ShowSelectionAt(Vector3 position)
    {
        _selectionVisual.SetActive(true);
        _selectionVisual.transform.position = position;
    }

    void Deselect()
    {
        _selectionVisual.SetActive(false);
        _selectedObject = null;
        _alreadyHasSelection = false;
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

    async void SwapChips(GameObject chipObj1, GameObject chipObj2)
    {
        try
        {

            IChip chip1 = chipObj1.GetComponent<IChip>();
            IChip chip2 = chipObj2.GetComponent<IChip>();

            Deselect();

            var swap = await _chipMovement.SwapAsync(chip1, chip2);

            if (_matchChecker.GetMatch(chip1).Count >= 3 || _matchChecker.GetMatch(chip2).Count >= 3)
            {
                _fieldCleaner.ChangeFillDirection(  chipObj2.GetComponent<IChip>().X,
                                                    chipObj2.GetComponent<IChip>().Y,
                                                    chipObj1.GetComponent<IChip>().X,
                                                    chipObj1.GetComponent<IChip>().Y);
                _fieldCleaner.ClearAndRefillBoard();
                _playerController.MoveAction();
            }
            else
            {
                var swapback = await _chipMovement.SwapAsync(chip2, chip1);
            }
        }
        catch (Exception e)
        {
            Debug.LogErrorFormat("AHTUNG: {0}", e);
            Debug.LogErrorFormat("Trying to swap {0} and {1}", chipObj1, chipObj2);
        }
    }


    //DEBUG
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            _fieldCleaner.ClearChipAndRefillAsync(_selectedObject.GetComponent<IChip>().X, _selectedObject.GetComponent<IChip>().Y);
            Deselect();
        }
    }
}
