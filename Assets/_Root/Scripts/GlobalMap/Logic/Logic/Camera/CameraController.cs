using Cinemachine;
using UnityEngine;

namespace GlobalMap
{
    public class CameraController : ICameraController
    {
        readonly CinemachineVirtualCamera _camera;

        public CameraController(CinemachineVirtualCamera cinemachineVirtualCamera)
        {
            _camera = cinemachineVirtualCamera;
        }

        public void FocusCamera(Transform target)
        {
            _camera.Follow = target;
        }
    }

}
