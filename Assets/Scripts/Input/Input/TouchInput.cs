using DigitalRubyShared;
using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour, ITouchInput
{
    //public Chip SelectedChip;
    public GameObject test;

    private TapGestureRecognizer tapGesture;

    Camera _camera;

    [Inject]
    public void Construct(Camera cam)
    {
        _camera = cam;
        CreateTapGesture();
    }

    private void TapGestureCallback(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended)
        {
            Debug.LogFormat("Tapped at {0}, {1}", gesture.FocusX, gesture.FocusY);
            CreateAsteroid(gesture.FocusX, gesture.FocusY);
        }
    }

    private void CreateTapGesture()
    {
        tapGesture = new TapGestureRecognizer();
        tapGesture.StateUpdated += TapGestureCallback;
        FingersScript.Instance.AddGesture(tapGesture);
    }

    private GameObject CreateAsteroid(float screenX, float screenY)
    {
        GameObject o = GameObject.Instantiate(test) as GameObject;
        o.name = "Test";

        if (screenX == float.MinValue || screenY == float.MinValue)
        {
            float x = Random.Range(_camera.rect.min.x, _camera.rect.max.x);
            float y = Random.Range(_camera.rect.min.y, _camera.rect.max.y);
            Vector3 pos = new Vector3(x, y, 0.0f);
            pos = _camera.ViewportToWorldPoint(pos);
            pos.z = o.transform.position.z;
            o.transform.position = pos;
        }
        else
        {
            Vector3 pos = new Vector3(screenX, screenY, 0.0f);
            pos = _camera.ScreenToWorldPoint(pos);
            pos.z = o.transform.position.z;
            o.transform.position = pos;
        }
        return o;
    }
}
