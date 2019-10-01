using Cinemachine;
using UnityEngine;

namespace GlobalMap
{
    public class TouchInputProcessor : ITouchProcessor
    {
        readonly CinemachineVirtualCamera _virtualCamera;
        Vector3 _newCameraPosition = new Vector3(0,0,-10);


        public TouchInputProcessor(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _virtualCamera = cinemachineVirtualCamera;
        }

        public void Drag(float deltaX, float deltaY)
        {
            _virtualCamera.Follow = null;
            _newCameraPosition.x = -deltaX;
            _newCameraPosition.y = -deltaY;
            _virtualCamera.transform.Translate(_newCameraPosition.normalized * 0.5f, Space.World);
        }

        public void EndOfDrag(Vector3 camPosition)
        {
            _virtualCamera.transform.position = camPosition;
        }

        public void TapOnObject(Transform tappedTransform)
        {
            var ClickedObject = tappedTransform.gameObject.GetComponent<IClickable>();

            if (ClickedObject != null)
            {
                ClickedObject.OnClickedAsync();
            }
        }
    }
}