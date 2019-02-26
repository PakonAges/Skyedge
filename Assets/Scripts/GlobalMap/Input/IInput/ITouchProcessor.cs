using UnityEngine;

namespace GlobalMap
{
    public interface ITouchProcessor
    {
        void TapOnObjectAsync(Transform tappedTransform);
        void Drag(float deltaX, float deltaY);
        void EndOfDrag(Vector3 camPosition);
    }
}