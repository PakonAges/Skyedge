using DigitalRubyShared;
using System;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    GameObject _selectedObject = null;
    bool _alreadyHasSelection = false;
    GameObject _selectionVisual;

    float _panDeadZone = 4.0f;

    GameObject _selectedChipVisualizationPrefab;
    //GestureTouch _touchGesture;
    TapGestureRecognizer _tapGesture;
    PanGestureRecognizer _panGesture;

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
        InitPanGesture();
        InitSelectionView();
    }

    Transform GestureHit(GestureRecognizer gesture)
    {
        Vector3 pos = new Vector3(gesture.FocusX, gesture.FocusY, 0.0f);
        pos = _camera.ScreenToWorldPoint(pos);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

        return hit.transform;
    }

    void TapGestureCallback(GestureRecognizer tapGesture)
    {
        if (tapGesture.State == GestureRecognizerState.Ended)
        {
            var tappedTransform = GestureHit(tapGesture);

            if (tappedTransform != null) // no hit
            {
                if (_selectedObject == null) //no selection
                {
                    SelectObject(tappedTransform.gameObject);
                }
                else if (_selectedObject == tappedTransform.gameObject) //clicked the same item
                {
                    Deselect();
                }
                else if (_chipMovement.GameField.IsAdjacement(_selectedObject.GetComponent<IChip>(), tappedTransform.gameObject.GetComponent<IChip>())) //Second Chip is Adjacement
                {
                    SwapChips(_selectedObject, tappedTransform.gameObject);
                }
                else //Second chip is not Adjacement
                {
                    ChangeSelection(tappedTransform.gameObject);
                }
            }
        }
    }

    void PanGestureCallback(GestureRecognizer panGesture)
    {
        if (panGesture.State == GestureRecognizerState.Began)
        {
            var pannedTransform = GestureHit(panGesture);

            //Hitted something
            if (pannedTransform != null)
            {
                //ok, let's try without showing selection
                if (panGesture.DeltaX > _panDeadZone)
                {
                    SwapChipInDirection(pannedTransform.gameObject, MoveDirection.LeftToRight);
                } else if (-1 * panGesture.DeltaX > _panDeadZone)
                {
                    SwapChipInDirection(pannedTransform.gameObject, MoveDirection.RightToLeft);
                } else if (panGesture.DeltaY > _panDeadZone)
                {
                    SwapChipInDirection(pannedTransform.gameObject, MoveDirection.BotToTop);
                } else if (-1 * panGesture.DeltaY > _panDeadZone)
                {
                    SwapChipInDirection(pannedTransform.gameObject, MoveDirection.TopToBot);
                }
            }
        }
    }



    void InitTapGesture()
    {
        _tapGesture = new TapGestureRecognizer();
        _tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(_tapGesture);
    }

    void InitPanGesture()
    {
        _panGesture = new PanGestureRecognizer();
        _panGesture.StateUpdated += PanGestureCallback;
        _panGesture.MaximumNumberOfTouchesToTrack = 2;
        FingersScript.Instance.AddGesture(_panGesture);
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
                await _fieldCleaner.ClearAndRefillBoardAsync();
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

    async void SwapChipInDirection(GameObject chip, MoveDirection direction)
    {
        try
        {
            IChip chip1 = chip.GetComponent<IChip>();
            IChip chip2 = null;

            if (CantSwap(chip1, direction))
            {
                Deselect();
                return;
            }

            if (direction == MoveDirection.TopToBot)
            {
                chip2 = _chipMovement.GameField.FieldMatrix[chip1.X, chip1.Y + 1];
            }
            else if (direction == MoveDirection.BotToTop)
            {
                chip2 = _chipMovement.GameField.FieldMatrix[chip1.X, chip1.Y - 1];
            }
            else if (direction == MoveDirection.RightToLeft)
            {
                chip2 = _chipMovement.GameField.FieldMatrix[chip1.X - 1, chip1.Y];
            }
            else if (direction == MoveDirection.LeftToRight)
            {
                chip2 = _chipMovement.GameField.FieldMatrix[chip1.X + 1, chip1.Y];
            }

            Deselect();

            var swap = await _chipMovement.SwapAsync(chip1, chip2);

            if (_matchChecker.GetMatch(chip1).Count >= 3 || _matchChecker.GetMatch(chip2).Count >= 3)
            {
                _fieldCleaner.ChangeFillDirection(direction);
                await _fieldCleaner.ClearAndRefillBoardAsync();
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
            Debug.LogErrorFormat("Trying to swap {0} in Direction {1}", chip, direction);
        }
    }

    private bool CantSwap(IChip chip1, MoveDirection direction)
    {
        if (chip1.X == 0 && direction == MoveDirection.RightToLeft)
        {
            return true;
        }
        if (chip1.X == _matchChecker.GameField.Xsize - 1 && direction == MoveDirection.LeftToRight)
        {
            return true;
        }
        if (chip1.Y == 0 && direction == MoveDirection.BotToTop)
        {
            return true;
        }
        if (chip1.Y == _matchChecker.GameField.Ysize - 1 && direction == MoveDirection.TopToBot)
        {
            return true;
        }

        return false;
    }

    //DEBUG
    void Update()
    {
        //ProcessTouches();

        if (Input.GetKeyDown(KeyCode.K))
        {
            _fieldCleaner.ClearChipAndRefillAsync(_selectedObject.GetComponent<IChip>().X, _selectedObject.GetComponent<IChip>().Y);
            Deselect();
        }
    }

    //private void ProcessTouches()
    //{
    //    for (int i = 0; i < Input.touchCount; i++)
    //    {
    //        Touch t = Input.GetTouch(i);
    //        var tras = GestureHit();
    //    }
    //}
}
