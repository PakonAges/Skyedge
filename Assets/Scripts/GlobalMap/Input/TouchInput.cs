using DigitalRubyShared;
using UnityEngine;
using Zenject;

namespace GlobalMap
{
    public class TouchInput : MonoBehaviour, ITouchInput
    {
        TapGestureRecognizer _tapGesture;
        PanGestureRecognizer _panGesture;

        Camera _camera;
        ITouchProcessor _touchProcessor;

        [Inject]
        public void Construct(Camera cam, ITouchProcessor touchProcessor)
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
            if (tapGesture.State == GestureRecognizerState.Ended)
            {
                var tappedTransform = GestureHit(tapGesture);

                if (tappedTransform != null) // check for hit
                {
                    //Select Region
                    _touchProcessor.TapOnObject(tappedTransform);
                }
            }
        }

        void PanGestureCallback(GestureRecognizer panGesture)
        {
            if (panGesture.State == GestureRecognizerState.Executing)
            {
                _touchProcessor.Drag( panGesture.DeltaX, panGesture.DeltaY);
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
}