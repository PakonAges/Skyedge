using DigitalRubyShared;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    public float DragTreshHold = 1.0f;

    TapGestureRecognizer _tapGesture;
    PanGestureRecognizer _panGesture;

    Camera _camera;
    ITouchProcessor _touchProcessor;
    Transform _tappedTransform = null;
    Transform _pannedTransform = null;


    [Inject]
    public void Construct(  Camera cam, ITouchProcessor touchProcessor)
    {
        _camera = cam;
        _touchProcessor = touchProcessor;

        InitTapGesture();
        InitPanGesture();
    }

    Transform GestureHit(GestureRecognizer gesture)
    {
        Vector3 pos = new Vector3(gesture.FocusX, gesture.FocusY, 0.0f);
        pos = _camera.ScreenToWorldPoint(pos);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

        return hit.transform;
    }

    Transform GestureHit(float FocusX, float FocusY)
    {
        Vector3 pos = new Vector3(FocusX, FocusY, 0.0f);
        pos = _camera.ScreenToWorldPoint(pos);
        RaycastHit2D hit = Physics2D.Raycast(pos, Vector3.zero);

        return hit.transform;
    }


    void TapGestureCallback(GestureRecognizer tapGesture)
    {
        if (tapGesture.State == GestureRecognizerState.Possible)
        {
            _tappedTransform = GestureHit(tapGesture);

            if (_tappedTransform != null) // check for hit
            {
                _touchProcessor.TapOnObject(_tappedTransform);
                _tappedTransform = null;
            }
        }
    }

    void PanGestureCallback(GestureRecognizer panGesture)
    {
        if (panGesture.State == GestureRecognizerState.Began)
        {
            if (Mathf.Abs(panGesture.DeltaX) >= DragTreshHold || Mathf.Abs(panGesture.DeltaY) >= DragTreshHold)
            {
                _pannedTransform = GestureHit(panGesture.StartFocusX, panGesture.StartFocusY);
                //Hitted something
                if (_pannedTransform != null)
                {
                    _touchProcessor.PanObject(_pannedTransform, panGesture.DeltaX, panGesture.DeltaY);
                    _pannedTransform = null;
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
        _panGesture.MaximumNumberOfTouchesToTrack = 1;
        FingersScript.Instance.AddGesture(_panGesture);
    }
}
