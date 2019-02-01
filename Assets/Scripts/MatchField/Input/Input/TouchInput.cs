using DigitalRubyShared;
using System;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    //GestureTouch _touchGesture;
    TapGestureRecognizer _tapGesture;
    PanGestureRecognizer _panGesture;

    Camera _camera;
    ITouchProcessor _touchProcessor;
    
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
            var pannedTransform = GestureHit(panGesture);

            //Hitted something
            if (pannedTransform != null)
            {
                _touchProcessor.PanObject(pannedTransform, panGesture.DeltaX, panGesture.DeltaY);
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
}
