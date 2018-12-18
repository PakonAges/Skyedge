using UnityEngine;

public interface IChipPositionProvider
{
    Vector3 GetPosition(int elementX, int elementY);
    float CalculateItemSize(Camera camera, int FieldItemsAmountX, int FieldItemsAmountY);
}