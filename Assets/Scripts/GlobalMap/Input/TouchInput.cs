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

        void OnDisable()
        {
            _tapGesture.StateUpdated -= TapGestureCallback;
            _panGesture.StateUpdated -= PanGestureCallback;
            //FingersScript.Instance.RemoveGesture(_tapGesture);
            //FingersScript.Instance.RemoveGesture(_panGesture);
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
            if (panGesture.State == GestureRecognizerState.Executing)
            {
                _touchProcessor.Drag( panGesture.DeltaX, panGesture.DeltaY);
            }
            else if(panGesture.State == GestureRecognizerState.Ended)
            {
                _touchProcessor.EndOfDrag(_camera.transform.position);
            }
        }

        void InitTapGesture()
        {
            _tapGesture = new TapGestureRecognizer();
            _tapGesture.StateUpdated += TapGestureCallback;
            FingersScript.Instance.AddGesture(_tapGesture);
            FingersScript.Instance.CaptureGestureHandler = CaptureGestureHandler;
        }

        void InitPanGesture()
        {
            _panGesture = new PanGestureRecognizer();
            _panGesture.StateUpdated += PanGestureCallback;
            _panGesture.MaximumNumberOfTouchesToTrack = 1;
            FingersScript.Instance.AddGesture(_panGesture);
        }

        private static bool? CaptureGestureHandler(GameObject obj)
        {
            if (obj.layer == 5)
            {
                return true;
            }
            //else if (obj.layer != 5)
            //{
            //    return false;
            //}
            // fall-back to default behavior for anything else
            return null;
        }
    }
}