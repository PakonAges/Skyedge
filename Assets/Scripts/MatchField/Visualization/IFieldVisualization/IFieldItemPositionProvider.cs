using UnityEngine;

public interface IFieldItemPositionProvider
{
    Vector3 GetPosition(int elementX, int elementY);
    float CalculateItemSize(Camera camera, int FieldItemsAmountX, int FieldItemsAmountY);
}