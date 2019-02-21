using Cinemachine;
using UnityEngine;

namespace GlobalMap
{
    public class TouchInputProcessor : ITouchProcessor
    {
        readonly CinemachineVirtualCamera _virtualCamera;
        Vector3 _newCameraPosition = new Vector3(0,0,-10);
        Vector2 _focusPosition = new Vector2();

        public TouchInputProcessor(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _virtualCamera = cinemachineVirtualCamera;
        }

        public void Drag(float deltaX, float deltaY)
        {
            _newCameraPosition.x = -deltaX;
            _newCameraPosition.y = -deltaY;

            _virtualCamera.transform.Translate(_newCameraPosition, Space.World);
        }

        public void TapOnObject(Transform tappedTransform)
        {
            throw new System.NotImplementedException();
        }
    }
}