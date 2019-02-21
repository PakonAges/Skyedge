using UnityEngine;

namespace GlobalMap
{
    public interface ITouchProcessor
    {
        void TapOnObject(Transform tappedTransform);
        void Drag(float deltaX, float deltaY);
    }
}