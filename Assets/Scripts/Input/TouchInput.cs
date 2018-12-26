using UnityEngine;
using Zenject;

public class TouchInput : MonoBehaviour
{
    //public Chip SelectedChip;
    public GameObject test;

    Camera _camera;

    [Inject]
    public void Construct(Camera cam)
    {
        _camera = cam;
    }

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                Ray touchRay = _camera.ScreenPointToRay(touch.position);

                if (Physics.Raycast(touchRay))
                {
                    Instantiate(test);
                }
            }
        }
    }
}
