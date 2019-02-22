using DigitalRubyShared;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    public float DragTreshHold = 1.0f;

    GestureRecognizer _touchGesture;
    TapGestureRecognizer _tapGesture;
    PanGestureRecognizer _panGesture;

    Camera _camera;
    ITouchProcessor _touchProcessor;
    
    [Inject]
    public void Construct(  Camera cam, ITouchProcessor touchProcessor)
    {
        _camera = cam;
        _touchProcessor = touchProcessor;

        InitTouch();
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

    void TouchGestureCallback(GestureRecognizer TouchGesture)
    {
        if (TouchGesture.CurrentTrackedTouches.Count > 0)
        {
            var tappedTransform = GestureHit(TouchGesture.CurrentTrackedTouches[0].X, TouchGesture.CurrentTrackedTouches[0].Y);

            if (tappedTransform != null) // check for hit
            {
                _touchProcessor.TapOnObject(tappedTransform);
            }
        }
    }

    void TapGestureCallback(GestureRecognizer tapGesture)
    {
        if (tapGesture.State == GestureRecognizerState.Ended)
        {
            var tappedTransform = GestureHit(tapGesture);

            if (tappedTransform != null) // check for hit
            {
                _touchProcessor.TapOnObject(tappedTransform);
            }
        }
    }

    void PanGestureCallback(GestureRecognizer panGesture)
    {
        if (panGesture.State == GestureRecognizerState.Began)
        {
            var pannedTransform = GestureHit(panGesture.StartFocusX, panGesture.StartFocusY);

            if (Mathf.Abs(panGesture.DeltaX) >= DragTreshHold || Mathf.Abs(panGesture.DeltaY) >= DragTreshHold)
            {
                //Hitted something
                if (pannedTransform != null)
                {
                    _touchProcessor.PanObject(pannedTransform, panGesture.DeltaX, panGesture.DeltaY);
                }
            }
        }
    }

    void InitTouch()
    {
        _touchGesture = new TouchGestureRecognizer();
        _touchGesture.StateUpdated += TouchGestureCallback;
        FingersScript.Instance.AddGesture(_touchGesture);
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
